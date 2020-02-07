using DataAccessLayer;
using Entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace BusinessLogicalLayer
{
    public class LocacaoService : IEntityCRUDEF<LocacaoEF>, ILocacaoServiceEF
    {
        public DataResponse<LocacaoEF> GetByID(int id)
        {
            DataResponse<LocacaoEF> dResponse = new DataResponse<LocacaoEF>();

            using (LocadoraDbContext db = new LocadoraDbContext())
            {
                try
                {
                    LocacaoEF locacao = db.Locacoes.Find(id);

                    List<LocacaoEF> locacaos = new List<LocacaoEF>();
                    locacaos.Add(locacao);

                    dResponse.Data = locacaos;
                    dResponse.Sucesso = true;
                    return dResponse;
                }
                catch (Exception ex)
                {
                    //Logar o erro pro ADM ter acesso.
                    File.WriteAllText("log.txt", ex.Message);

                    dResponse.Sucesso = false;
                    dResponse.Erros.Add("Falha ao acessar o banco de dados, contate o suporte.");
                    return dResponse;
                }
            }
        }

        public DataResponse<LocacaoEF> GetData()
        {
            DataResponse<LocacaoEF> dResponse = new DataResponse<LocacaoEF>();

            using (LocadoraDbContext db = new LocadoraDbContext())
            {
                try
                {
                    List<LocacaoEF> locacaos = db.Locacoes.Select(l => new LocacaoEF()
                    {
                        ID = l.ID,
                        Cliente = l.Cliente,
                        Funcionario = l.Funcionario,
                        Preco = l.Preco,
                        DataLocacao = l.DataLocacao,
                        DataDevolucaoPrevista = l.DataDevolucaoPrevista,
                        DataDevolucao = l.DataDevolucao,
                        Multa = l.Multa,
                        FoiPago = l.FoiPago

                    }).ToList();

                    dResponse.Data = locacaos;
                    dResponse.Sucesso = true;
                    return dResponse;
                }
                catch (Exception ex)
                {

                    dResponse.Sucesso = false;

                    if (ex.Message.Contains("FK"))
                    {
                        dResponse.Erros.Add("FIlme não encontrado.");
                    }
                    else
                    {
                        dResponse.Erros.Add("Erro no banco de dados, contate o ADM!");
                        File.WriteAllText("log.txt", ex.Message);
                        return dResponse;
                    }
                    return dResponse;
                }
            }
        }

        public Response Insert(LocacaoEF item)
        {
            Response response = new Response();

            using (LocadoraDbContext db = new LocadoraDbContext())
            {
                try
                {
                    db.Locacoes.Add(item);
                    db.SaveChanges();

                    response.Sucesso = true;
                    return response;
                }
                catch (Exception ex)
                {
                    response.Sucesso = false;

                    if (ex.Message.Contains("FK"))
                    {
                        response.Erros.Add("Gênero não encontrado.");
                    }
                    else
                    {
                        response.Erros.Add("Erro no banco de dados, contate o ADM!");
                        File.WriteAllText("log.txt", ex.Message);
                        return response;
                    }
                    return response;
                }
            }
        }


        public Response Update(LocacaoEF item)
        {
            Response response = new Response();

            using (LocadoraDbContext db = new LocadoraDbContext())
            {
                try
                {
                    db.Entry<LocacaoEF>(item).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();

                    response.Sucesso = true;
                    return response;
                }
                catch (Exception ex)
                {
                    response.Sucesso = false;

                    if (ex.Message.Contains("FK"))
                    {
                        response.Erros.Add("Filme não encontrado.");
                    }
                    else
                    {
                        response.Erros.Add("Erro no banco de dados, contate o ADM!");
                        File.WriteAllText("log.txt", ex.Message);
                        return response;
                    }
                    return response;
                }
            }
        }
        public Response Delete(int id)
        {
            DataResponse<LocacaoEF> dResponse = new DataResponse<LocacaoEF>();

            using (LocadoraDbContext db = new LocadoraDbContext())
            {
                try
                {
                    LocacaoEF locacao = db.Locacoes.Find(id);

                    List<LocacaoEF> locacaos = new List<LocacaoEF>();
                    locacaos.Add(locacao);

                    dResponse.Data = locacaos;
                    dResponse.Sucesso = true;
                    return dResponse;
                }
                catch (Exception ex)
                {
                    dResponse.Sucesso = false;

                    if (ex.Message.Contains("LOCACAOES_FILMES"))
                    {
                        dResponse.Erros.Add("Filme não pode ser excluído, pois não há locações.");
                    }
                    else
                    {
                        dResponse.Erros.Add("Erro no banco de dados, contate o ADM!");
                        File.WriteAllText("log.txt", ex.Message);
                        return dResponse;
                    }
                    return dResponse;
                }
            }
        }

        public Response EfeturarLocacao(LocacaoEF locacao)
        {
            Response response = new Response();

            using (TransactionScope scope = new TransactionScope())
            {
                using (LocadoraDbContext locadora = new LocadoraDbContext())
                {
                    locadora.Locacoes.Add(locacao);
                }

                if (response.Sucesso)
                {
                    //response = dal.EfetuarFilmesLocacao(locacao);
                    if (response.Sucesso)
                    {
                        scope.Complete();
                    }
                }
            }

            return response;
        }
    }
}
