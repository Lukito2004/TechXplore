using TechXplore.Application.Repositories;
using TechXplore.Application.Services.Banking;
using TechXplore.Application.Services.Categories;
using TechXplore.Application.Services.Limits;
using TechXplore.Application.Services.Rents;
using TechXplore.Application.Services.Users;
using TechXplore.Infrastructure.Repositories.Categories;
using TechXplore.Infrastructure.Repositories.Companies;
using TechXplore.Infrastructure.Repositories.Limits;
using TechXplore.Infrastructure.Repositories.Rents;
using TechXplore.Infrastructure.Repositories.Transactions;
using TechXplore.Infrastructure.Repositories.Users;

namespace View.Infrastructure.Extensions
{
    public static class ServiceExtensions
    {
        public static void AddServices(this IServiceCollection services)
        {
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<ITransactionRepository, TransactionRepository>();
            services.AddScoped<ICompanyRepository, CompanyRepository>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IBankingService, BankingService>();
            services.AddScoped<ILimitRepository, LimitRepository>();
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<ILimitService, LimitService>();
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<IRentRepository, RentRepository>();
            services.AddScoped<IRentService, RentService>();
        }
    }
}
