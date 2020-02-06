using Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicalLayer.Mappings
{
    internal class ClienteMapConfig : EntityTypeConfiguration<Cliente>
    {
        public ClienteMapConfig()
        {
            this.ToTable("CLIENTS");
            this.Property(c => c.Name).HasMaxLength(50);
            this.Property(c => c.CPF).IsFixedLength().HasMaxLength(14);
            this.Property(c => c.Email).HasMaxLength(50);
            this.Property(c => c.Birth_Day).HasColumnType("date");
            this.Property(c => c.IsActive).HasColumnType("bit");
        }
    }
}
