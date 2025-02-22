using TechXplore.Application.Repositories;
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
        }
    }
}
