using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechXplore.Domain.Users;

namespace TechXplore.Persistence.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Username).IsRequired().HasMaxLength(20);
            builder.HasMany(x => x.Transactions).WithOne().HasForeignKey(x => x.UserId);
            builder.HasMany(x => x.Limits).WithOne().HasForeignKey(x => x.UserId);
            builder.HasMany(x => x.Rents).WithOne().HasForeignKey(x => x.UserId);
        }
    }
}
