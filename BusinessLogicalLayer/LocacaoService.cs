using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicalLayer
{
    public class LocacaoService : IEntityCRUDEF<LocacaoEF>, ILocacaoServiceEF
    {
        public DataResponse<LocacaoEF> GetByID(int id)
        {
            throw new NotImplementedException();
        }

        public DataResponse<LocacaoEF> GetData()
        {
            throw new NotImplementedException();
        }

        public Response Insert(LocacaoEF item)
        {
            throw new NotImplementedException();
        }

        public Response Update(LocacaoEF item)
        {
            throw new NotImplementedException();
        }
        public Response Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Response EfeturarLocacao(Locacao locacao)
        {
            throw new NotImplementedException();
        }
    }
}
