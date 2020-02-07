using DataAccessLayer;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicalLayer
{
    public class ClienteService : IEntityCRUDEF<ClienteEF>
    {
        public DataResponse<ClienteEF> GetByID(int id)
        {
            throw new NotImplementedException();
        }

        public DataResponse<ClienteEF> GetData()
        {
            throw new NotImplementedException();
        }

        public Response Insert(ClienteEF item)
        {
            throw new NotImplementedException();
        }

        public Response Update(ClienteEF item)
        {
            throw new NotImplementedException();
        }

        public Response Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}
