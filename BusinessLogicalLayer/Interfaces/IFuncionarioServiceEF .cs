using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public interface IFuncionarioServiceEF
    {
        DataResponse<FuncionarioEF> Autenticar(string email, string senha);
    }
}
