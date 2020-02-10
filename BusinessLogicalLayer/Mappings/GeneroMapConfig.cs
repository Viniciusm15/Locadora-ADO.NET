using Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicalLayer.Mappings
{
    internal class GeneroMapConfig : EntityTypeConfiguration<GeneroEF>
    {
        public GeneroMapConfig()
        {
            this.ToTable("GENERS");
            this.Property(g => g.Nome).HasMaxLength(40);
        }
    }
}
