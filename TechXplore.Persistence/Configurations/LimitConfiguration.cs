using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechXplore.Domain.Limits;

namespace TechXplore.Persistence.Configurations
{
    public class LimitConfiguration : IEntityTypeConfiguration<Limit>
    {
        public void Configure(EntityTypeBuilder<Limit> builder)
        {
            builder.HasKey(x => x.CategoryId);
            builder.Property(x => x.CategoryId)
                   .ValueGeneratedNever();
        }
    }
}
