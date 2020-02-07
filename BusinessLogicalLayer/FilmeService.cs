using DataAccessLayer;
using Entities;
using Entities.Enums;
using Entities.ResultSets;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicalLayer
{
    public class FilmeService : IEntityCRUDEF<FilmeEF>, IFilmeServiceEF
    {
        public DataResponse<FilmeEF> GetByID(int id)
        {
            DataResponse<FilmeEF> dResponse = new DataResponse<FilmeEF>();

            using (LocadoraDbContext db = new LocadoraDbContext())
            {
                try
                {
                    // List<FilmeEF> result = db.Filmes.Select(f => new FilmeEF()
                    //{
                    //    ID = f.ID,
                    //    Nome = f.Nome,
                    //    Classificacao = f.Classificacao,
                    //    DataLancamento = f.DataLancamento,
                    //    Duracao = f.Duracao,
                    //    GeneroID = f.GeneroID,
                    //    Genero = f.Genero

                    // }).ToList();

                    FilmeEF filme = db.Filmes.Find(id);

                    List<FilmeEF> filmes = new List<FilmeEF>();
                    filmes.Add(filme);

                    dResponse.Data = filmes;
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

        public DataResponse<FilmeEF> GetData()
        {
            DataResponse<FilmeEF> dResponse = new DataResponse<FilmeEF>();

            using (LocadoraDbContext db = new LocadoraDbContext())
            {
                try
                {
                    List<FilmeEF> result = db.Filmes.Select(f => new FilmeEF()
                    {
                        ID = f.ID,
                        Nome = f.Nome,
                        Classificacao = f.Classificacao,
                        DataLancamento = f.DataLancamento,
                        Duracao = f.Duracao,
                        GeneroID = f.GeneroID,
                        Genero = f.Genero

                    }).ToList();

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

        public Response Insert(FilmeEF item)
        {
            Response response = Validate(item);

            if (response.Erros.Count > 0)
            {
                response.Sucesso = false;
                return response;
            }

            using (LocadoraDbContext db = new LocadoraDbContext())
            {
                try
                {
                    List<FilmeResultSet> result = db.Filmes.Select(f => new FilmeResultSet()
                    {
                        ID = f.ID,
                        Nome = f.Nome,
                        Classificacao = f.Classificacao,
                        Genero = f.Genero.Nome
                    }).ToList();

                    DataResponse<FilmeResultSet> dResponse = new DataResponse<FilmeResultSet>();
                    dResponse.Data = result;
                    dResponse.Sucesso = true;
                    return dResponse;
                }
                catch (Exception ex)
                {
                    DataResponse<FilmeResultSet> dResponse = new DataResponse<FilmeResultSet>();
                    dResponse.Sucesso = false;

                    if (ex.Message.Contains("FK"))
                    {
                        dResponse.Erros.Add("Gênero não encontrado.");
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

        public Response Update(FilmeEF item)
        {
            Response response = Validate(item);

            if (response.Erros.Count > 0)
            {
                response.Sucesso = false;
                return response;
            }

            using (LocadoraDbContext db = new LocadoraDbContext())
            {
                try
                {
                    db.Entry<FilmeEF>(item).State = System.Data.Entity.EntityState.Modified;
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
            DataResponse<FilmeEF> dResponse = new DataResponse<FilmeEF>();

            using (LocadoraDbContext db = new LocadoraDbContext())
            {
                try
                {
                    FilmeEF filme = db.Filmes.Find(id);

                    List<FilmeEF> filmes = new List<FilmeEF>();
                    filmes.Add(filme);

                    dResponse.Data = filmes;
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

        public DataResponse<FilmeResultSet> GetFilmes()
        {
            using (LocadoraDbContext db = new LocadoraDbContext())
            {
                try
                {
                    List<FilmeResultSet> result = db.Filmes.Select(f => new FilmeResultSet()
                    {
                        ID = f.ID,
                        Nome = f.Nome,
                        Classificacao = f.Classificacao,
                        Genero = f.Genero.Nome
                    }).ToList();

                    DataResponse<FilmeResultSet> response = new DataResponse<FilmeResultSet>();
                    response.Data = result;
                    response.Sucesso = true;
                    return response;
                }
                catch (Exception ex)
                {
                    DataResponse<FilmeResultSet> response = new DataResponse<FilmeResultSet>();
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

        public DataResponse<FilmeResultSet> GetFilmesByName(string nome)
        {
            throw new NotImplementedException();
        }

        public DataResponse<FilmeResultSet> GetFilmesByGener(int genero)
        {
            throw new NotImplementedException();
        }

        public DataResponse<FilmeResultSet> GetFilmesByClassification(Classificacao classificacao)
        {
            throw new NotImplementedException();
        }

        private Response Validate(FilmeEF item)
        {
            Response response = new Response();

            if (string.IsNullOrWhiteSpace(item.Nome))
            {
                response.Erros.Add("O nome do filme deve ser informado.");
            }
            else
            {
                item.Nome = EXT.NormatizarNome(item.Nome);
                if (item.Nome.Length < 2 || item.Nome.Length > 100)
                {
                    response.Erros.Add("O nome do filme deve conter entre 2 e 100 caracteres.");
                }
                else if (!EXT.CorrectName(item.Nome))
                {
                    response.Erros.Add("O nome está no formato incorreto.");
                }
            }

            if (item.Duracao <= 10)
            {
                response.Erros.Add("A duração não pode ser menor que 10 minutos.");
            }

            if (item.DataLancamento.Equals(DateTime.MinValue) || item.DataLancamento > DateTime.Now)
            {
                response.Erros.Add("Data inválida.");
            }

            return response;
        }
    }
}
