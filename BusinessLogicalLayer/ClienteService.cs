using DataAccessLayer;
using Entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicalLayer
{
    public class ClienteService : IEntityCRUDEF<ClienteEF>
    {
        public DataResponse<ClienteEF> GetByID(int id)
        {
            DataResponse<ClienteEF> dResponse = new DataResponse<ClienteEF>();

            using (LocadoraDbContext db = new LocadoraDbContext())
            {
                try
                {
                    ClienteEF cliente = db.Clientes.Find(id);

                    List<ClienteEF> clientes = new List<ClienteEF>();
                    clientes.Add(cliente);

                    dResponse.Data = clientes;
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

        public DataResponse<ClienteEF> GetData()
        {
            DataResponse<ClienteEF> dResponse = new DataResponse<ClienteEF>();

            using (LocadoraDbContext db = new LocadoraDbContext())
            {
                try
                {
                    List<ClienteEF> clientes = db.Clientes.Select(c => new ClienteEF()
                    {
                        ID = c.ID,
                        Name = c.Name,
                        CPF = c.CPF,
                        Email = c.Email,
                        Birth_Day = c.Birth_Day,
                        IsActive = c.IsActive,

                    }).ToList();

                    dResponse.Data = clientes;
                    dResponse.Sucesso = true;
                    return dResponse;
                }
                catch (Exception ex)
                {

                    dResponse.Sucesso = false;

                    if (ex.Message.Contains("FK"))
                    {
                        dResponse.Erros.Add("Cliente não encontrado.");
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

        public Response Insert(ClienteEF item)
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
                    db.Clientes.Add(item);
                    db.SaveChanges();

                    response.Sucesso = true;
                    return response;
                }
                catch (Exception ex)
                {
                    response.Sucesso = false;

                    if (ex.Message.Contains("FK"))
                    {
                        response.Erros.Add("Cliente não encontrado.");
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

        private Response Validate(ClienteEF item)
        {
            Response response = new Response();

            if (string.IsNullOrWhiteSpace(item.Name))
            {
                response.Erros.Add("Informe o seu nome.");
            }
            else
            {
                item.Name = EXT.NormatizarNome(item.Name);
                if (item.Name.Length < 2 || item.Name.Length > 50)
                {
                    response.Erros.Add("O nome deve conter entre 2 e 50 caracteres.");
                }
                else if (!EXT.CorrectName(item.Name))
                {
                    response.Erros.Add("O nome está no formato incorreto.");
                }
            }

            if (string.IsNullOrWhiteSpace(item.CPF))
            {
                response.Erros.Add("Informe o seu CPF.");
            }
            else
            {
                item.CPF = EXT.NormatizarCPF(item.CPF);
                if (item.CPF.Length < 2 || item.CPF.Length > 50)
                {
                    response.Erros.Add("O CPF deve conter entre 2 e 50 caracteres.");
                }
                else if (!EXT.IsCpf(item.CPF))
                {
                    response.Erros.Add("O CPF deve estar no formato correto.");
                }
            }

            if (string.IsNullOrWhiteSpace(item.Email))
            {
                response.Erros.Add("Informe o seu email.");
            }
            else
            {
                item.Email = EXT.NormatizarEmail(item.Email);
                if (item.Email.Length < 2 || item.Email.Length > 50)
                {
                    response.Erros.Add("O email deve conter entre 2 e 50 caracteres.");
                }
                else if (!EXT.IsEmail(item.Email))
                {
                    response.Erros.Add("O email deve estar no formato correto.");
                }
            }

            return response;
        }
    

        public Response Update(ClienteEF item)
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
                    db.Entry<ClienteEF>(item).State = System.Data.Entity.EntityState.Modified;
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
            DataResponse<ClienteEF> dResponse = new DataResponse<ClienteEF>();

            using (LocadoraDbContext db = new LocadoraDbContext())
            {
                try
                {
                    ClienteEF cliente = db.Clientes.Find(id);

                    List<ClienteEF> clientes = new List<ClienteEF>();
                    clientes.Add(cliente);

                    dResponse.Data = clientes;
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
    }
}
