using Domain.Entities.staffs;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Peristance.Configuration
{
    public class StaffConfiguration:IEntityTypeConfiguration<Staff>

    { 

        public void Configure(EntityTypeBuilder<Staff> builder)
        {
            builder.HasKey(e => e.Id);
            builder.Property(e => e.FastName).IsRequired(false);
            builder.Property(e => e.LastName).IsRequired(false);
            builder.Property(e => e.City).HasColumnType("varchar");
            builder.Property(e => e.State).HasColumnType("varchar");
            builder.Property(e => e.Country).HasColumnType("varchar");
            builder.HasIndex(e => e.Description).IsUnique();
        }
    }

}
