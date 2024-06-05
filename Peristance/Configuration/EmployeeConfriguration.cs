using Domain.Entities.Employees;
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
    public class EmployeeConfriguration : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        { 
            builder.HasKey(e => e.Id);
            builder.Property(e => e.Name).IsRequired(false);
            builder.Property(x => x.City).HasColumnType("varchar");
            builder.HasIndex(e => e.PostalCode).IsUnique();
        }
      
        
    }
}
