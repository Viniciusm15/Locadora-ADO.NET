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
    public class LocacaoService : ILocacaoServiceEF
    {
        public Response EfeturarLocacao(LocacaoEF locacao)
        {
            Response response = new Response();

            using (LocadoraDbContext db = new LocadoraDbContext())
            {
                db.Locacoes.Add(locacao);

            }

            return response;
        }
    }
}
