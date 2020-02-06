using Entities;
using Entities.Enums;
using Entities.ResultSets;
using System;
using System.Collections.Generic;
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
            throw new NotImplementedException();
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
