using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class LocacaoEF
    {
        public int ID { get; set; }
        public int? ClienteID { get; set; }
        public virtual ClienteEF Cliente { get; set; }
        public int? FuncionarioID { get; set; }
        public virtual FuncionarioEF Funcionario { get; set; }
        public double Preco { get; set; }
        public double Multa { get; set; }
        public DateTime DataLocacao { get; set; }
        public DateTime DataDevolucaoPrevista { get; set; }
        public DateTime? DataDevolucao { get; set; }
        public virtual List<FilmeEF> Filmes { get; set; }
        public bool FoiPago { get; set; }

        public LocacaoEF()
        {
            this.Filmes = new List<FilmeEF>();
        }
    }
}
