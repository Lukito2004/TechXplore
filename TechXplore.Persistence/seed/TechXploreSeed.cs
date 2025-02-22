using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using TechXplore.Domain.Categories;
using TechXplore.Domain.Companies;
using TechXplore.Domain.Limits;
using TechXplore.Domain.Rents;
using TechXplore.Domain.Transactions;
using TechXplore.Domain.Users;
using TechXplore.Persistence.Context;

namespace TechXplore.Persistence.seed
{
    public class TechXploreSeed
    {
        public static void Initialize(IServiceProvider service)
        {
            using var scope = service.CreateAsyncScope();

            var database = scope.ServiceProvider.GetRequiredService<TechXploreDBContext>();

            Migrate(database);

            SeedEverything(database);
        }

        private static void Migrate(TechXploreDBContext context)
        {
            context.Database.Migrate();
        }

        private static void SeedEverything(TechXploreDBContext context)
        {

            SeedUser(context);
            context.SaveChanges();

            SeedCategories(context);
            context.SaveChanges();

            SeedCompanies(context);
            context.SaveChanges();

            SeedTransactions(context);
            context.SaveChanges();

            SeedLimits(context);
            context.SaveChanges();

        }

        private static void SeedUser(TechXploreDBContext context)
        {
            User user = new User() { ESGScore = 0, Money = 1000, Username = "Lukito0310" };
            if (context.Users.Any(x => x.Id == 1))
                return;
            context.Users.Add(user);
        }

        private static void SeedCategories(TechXploreDBContext context)
        {
            List<Category> categories = new List<Category>()
            {
                new Category { Name = "საყიდლები" },
                new Category { Name = "კომუნალური გადახდები" },
                new Category { Name = "გადარიცხვები" },
                new Category { Name = "ბანკი, დაზღვევა" },
                new Category { Name = "საოჯახო ხარჯი" },
                new Category { Name = "ჯანმრთელობა, სილამაზე" },
                new Category { Name = "რესტორანი, კაფე, ბარი" },
                new Category { Name = "გართობა" },
                new Category { Name = "ტრანსპორტი" },
                new Category { Name = "მოგზაურობა, დასვენება" },
                new Category { Name = "თანხის განაღდება" },
                new Category { Name = "სხვადასხვა ხარჯი" },
                new Category { Name = "დაუხარისხებელი ხარჯი" }
            };

            foreach (var category in categories)
            {
                if (context.Categories.Any(x => x.Id == category.Id)) 
                    continue;

                context.Categories.Add(category);
            }
        }

        private static void SeedTransactions(TechXploreDBContext context)
        {
            List<Transaction> transactions = new List<Transaction>()
            {
                new Transaction() { CompanyId = 2, MoneySpent = 50, TransactionTime = DateTime.Now, UserId = 1 },
                new Transaction() { CompanyId = 1, MoneySpent = 100, TransactionTime = DateTime.Now, UserId = 1 },
                new Transaction() { CompanyId = 3, MoneySpent = 200, TransactionTime = DateTime.Now, UserId = 1 },
            };

            foreach (var transaction in transactions)
            {
                if (context.Transactions.Any(x => x.Id == transaction.Id)) 
                    continue;

                context.Transactions.Add(transaction);
            }
        }

        private static void SeedLimits(TechXploreDBContext context)
        {
            List<Limit> limits = new List<Limit>()
            {
                new Limit() {MoneyLimit = 300, CategoryId = 1, UserId = 1},
                new Limit() {MoneyLimit = 800, CategoryId = 2, UserId = 1},
                new Limit() {MoneyLimit = 900, CategoryId = 3, UserId = 1},
                new Limit() {MoneyLimit = 1200, CategoryId = 4, UserId = 1},
                new Limit() {MoneyLimit = 1500, CategoryId = 5, UserId = 1},
                new Limit() {MoneyLimit = 450, CategoryId = 6, UserId = 1},
                new Limit() {MoneyLimit = 620, CategoryId = 7, UserId = 1},
                new Limit() {MoneyLimit = 820, CategoryId = 8, UserId = 1},
                new Limit() {MoneyLimit = 960, CategoryId = 9, UserId = 1},
                new Limit() {MoneyLimit = 1200, CategoryId = 10, UserId = 1},
                new Limit() {MoneyLimit = 990, CategoryId = 11, UserId = 1},
                new Limit() {MoneyLimit = 2000, CategoryId = 12, UserId = 1},
                new Limit() {MoneyLimit = 250, CategoryId = 13, UserId = 1}
            };

            foreach (var limit in limits)
            {
                if (context.Limits.Any(x => x.CategoryId == limit.CategoryId))
                    continue;

                context.Limits.Add(limit);
            }
        }

        private static void SeedCompanies(TechXploreDBContext context)
        {
            List<Company> companies = new List<Company>()
            {
                new Company() {Name = "Gulf", ESGCoefficient = 1.2M, CategoryId = 9 },
                new Company() {Name = "Wissol", ESGCoefficient = 1.3M, CategoryId = 9 },
                new Company() {Name = "Rompetrol", ESGCoefficient = 1.4M, CategoryId = 9 }, 
                new Company() {Name = "Ori Nabiji", ESGCoefficient = 1.01M, CategoryId = 1 }
            };

            foreach (var company in companies)
            {
                if (context.Companies.Any(x => x.Id == company.Id)) 
                    continue;

                context.Companies.Add(company);
            }
        }
    }
}
