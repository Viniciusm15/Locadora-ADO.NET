using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicalLayer
{
    public class FuncionarioService : IEntityCRUDEF<FuncionarioEF>, IFuncionarioServiceEF
    {
        public Response Insert(FuncionarioEF item)
        {
            throw new NotImplementedException();
        }

        public Response Update(FuncionarioEF item)
        {
            throw new NotImplementedException();
        }

        public Response Delete(int id)
        {
            throw new NotImplementedException();
        }

        public DataResponse<FuncionarioEF> GetByID(int id)
        {
            throw new NotImplementedException();
        }

        public DataResponse<FuncionarioEF> GetData()
        {
            throw new NotImplementedException();
        }

        public DataResponse<Funcionario> Autenticar(string email, string senha)
        {
           
        }
    }
}
