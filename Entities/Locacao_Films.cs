using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Locacao_Films
    {
        public int? LocacaoID { get; set; }
        public virtual Locacao Locacao { get; set; }
        public int? FilmeID { get; set; }
        public virtual Filme Filme { get; set; }
    }
}
