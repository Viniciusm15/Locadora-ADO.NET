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
    public class GeneroService : IEntityCRUDEF<GeneroEF>
    {
        public Response Insert(GeneroEF item)
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
                    db.Generos.Add(item);
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

        public Response Update(GeneroEF item)
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
                    db.Entry<GeneroEF>(item).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();

                    response.Sucesso = true;
                    return response;
                }
                catch (Exception ex)
                {
                    response.Sucesso = false;

                    if (ex.Message.Contains("FK"))
                    {
                        response.Erros.Add("Genero não encontrado.");
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
            DataResponse<GeneroEF> dResponse = new DataResponse<GeneroEF>();

            using (LocadoraDbContext db = new LocadoraDbContext())
            {
                try
                {
                    GeneroEF genero = db.Generos.Find(id);

                    List<GeneroEF> generos = new List<GeneroEF>();
                    generos.Add(genero);

                    dResponse.Data = generos;
                    dResponse.Sucesso = true;
                    return dResponse;
                }
                catch (Exception ex)
                {
                    dResponse.Sucesso = false;

                    if (ex.Message.Contains("UQ"))
                    {
                        dResponse.Erros.Add("Gênero não cadastrado");
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

        public DataResponse<GeneroEF> GetByID(int id)
        {
            DataResponse<GeneroEF> dResponse = new DataResponse<GeneroEF>();

            using (LocadoraDbContext db = new LocadoraDbContext())
            {
                try
                {
                    GeneroEF genero = db.Generos.Find(id);

                    List<GeneroEF> generos = new List<GeneroEF>();
                    generos.Add(genero);

                    dResponse.Data = generos;
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

        public DataResponse<GeneroEF> GetData()
        {
            DataResponse<GeneroEF> dResponse = new DataResponse<GeneroEF>();

            using (LocadoraDbContext db = new LocadoraDbContext())
            {
                try
                {
                    List<GeneroEF> generos = db.Generos.Select(f => new GeneroEF()
                    {
                        ID = f.ID,
                        Nome = f.Nome,

                    }).ToList();

                    dResponse.Data = generos;
                    dResponse.Sucesso = true;
                    return dResponse;
                }
                catch (Exception ex)
                {

                    dResponse.Sucesso = false;

                    if (ex.Message.Contains("FK"))
                    {
                        dResponse.Erros.Add("Genero não encontrado.");
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

        private Response Validate(GeneroEF item)
        {
            Response response = new Response();

            if (string.IsNullOrWhiteSpace(item.Nome))
            {
                response.Erros.Add("Informe o seu nome.");
            }
            else
            {
                item.Nome = EXT.NormatizarNome(item.Nome);
                if (item.Nome.Length < 2 || item.Nome.Length > 50)
                {
                    response.Erros.Add("O nome deve conter entre 2 e 50 caracteres.");
                }
                else if (!EXT.CorrectName(item.Nome))
                {
                    response.Erros.Add("O nome está no formato incorreto.");
                }
            }
            return response;
        }
    }
}
