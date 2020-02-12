using Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicalLayer.Mappings
{
    internal class ClienteMapConfig : EntityTypeConfiguration<ClienteEF>
    {
        public ClienteMapConfig()
        {
            this.ToTable("CLIENTS");
            this.Property(c => c.Name).HasMaxLength(50);
            this.Property(c => c.CPF).IsFixedLength().HasMaxLength(14);
            this.HasIndex(c => c.CPF).IsUnique(true);
            this.Property(c => c.Email).HasMaxLength(50);
            this.HasIndex(c => c.Email).IsUnique(true);
            this.Property(c => c.Birth_Day).HasColumnType("date");
            this.Property(c => c.IsActive).HasColumnType("bit");
        }
    }
}
