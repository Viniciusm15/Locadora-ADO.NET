using Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicalLayer.Mappings
{
    internal class FuncionarioMapConfig : EntityTypeConfiguration<FuncionarioEF>
    {
        public FuncionarioMapConfig()
        {
            this.ToTable("FUNCTIONARIES");
            this.Property(f => f.Name).HasMaxLength(100);
            this.Property(f => f.BirthDate).HasColumnType("date");
            this.Property(f => f.CPF).IsFixedLength().HasMaxLength(14);
            this.Property(f => f.Email).HasMaxLength(50);
            this.Property(f => f.Telephone).HasMaxLength(15);
            this.Property(f => f.Password).HasMaxLength(100);
            this.Property(f => f.IsActive).HasColumnType("bit");
        }
    }
}
