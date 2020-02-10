using Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicalLayer.Mappings
{
    internal class FilmeMapConfig : EntityTypeConfiguration<FilmeEF>
    {
        public FilmeMapConfig()
        {
            this.ToTable("FILMS");
            this.Property(f => f.Nome).HasMaxLength(100);
            this.Property(f => f.DataLancamento).HasColumnType("date");
            this.Property(f => f.Classificacao).HasColumnType("int").IsRequired();
            this.Property(f => f.Duracao).HasColumnType("int").IsRequired();
            this.Property(f => f.GeneroID).HasColumnType("int").IsRequired();
        }
    }
}
