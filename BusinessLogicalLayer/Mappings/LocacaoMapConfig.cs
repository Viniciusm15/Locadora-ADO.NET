using Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicalLayer.Mappings
{
    internal class LocacaoMapConfig : EntityTypeConfiguration<Locacao>
    {
        public LocacaoMapConfig()
        {
            this.ToTable("LOCACOES");
            //this.Property(l => l.Cliente);
            //this.Property(l => l.Funcionario);
            this.Property(l => l.Preco).HasColumnType("float");
            this.Property(l => l.DataLocacao).HasColumnType("datetime2");
            this.Property(l => l.DataDevolucaoPrevista).HasColumnType("datetime2");
            this.Property(l => l.DataDevolucao).HasColumnType("datetime2");
            this.Property(l => l.Multa).HasColumnType("float");
            this.Property(l => l.FoiPago).HasColumnType("bit");
        }
    }
}
