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
            throw new NotImplementedException();
        }

        public DataResponse<FilmeEF> GetData()
        {
            throw new NotImplementedException();
        }

        public Response Insert(FilmeEF item)
        {
            throw new NotImplementedException();
        }

        public Response Update(FilmeEF item)
        {
            throw new NotImplementedException();
        }

        public Response Delete(int id)
        {
            throw new NotImplementedException();
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
    }
}
