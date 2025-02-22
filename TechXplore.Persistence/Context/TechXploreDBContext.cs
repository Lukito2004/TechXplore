using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechXplore.Domain.Categories;
using TechXplore.Domain.Companies;
using TechXplore.Domain.Limits;
using TechXplore.Domain.Rents;
using TechXplore.Domain.Transactions;
using TechXplore.Domain.Users;

namespace TechXplore.Persistence.Context
{
    public class TechXploreDBContext : DbContext
    {
        public TechXploreDBContext(DbContextOptions<TechXploreDBContext> options) : base(options)
        {

        }

        public DbSet<User> Users { get; set; }

        public DbSet<Category> Categories { get; set; }

        public DbSet<Transaction> Transactions { get; set; }

        public DbSet<Limit> Limits { get; set; }

        public DbSet<Company> Companies { get; set; }

        public DbSet<Rent> Rents { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(TechXploreDBContext).Assembly);
        }
    }
}
