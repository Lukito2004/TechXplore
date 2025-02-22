using Mapster;
using TechXplore.Application.CategoryModels;
using TechXplore.Application.LimitModels;
using TechXplore.Application.RentModels;
using TechXplore.Application.TransactionModels;
using TechXplore.Application.UserModels;
using TechXplore.Domain.Categories;
using TechXplore.Domain.Limits;
using TechXplore.Domain.Rents;
using TechXplore.Domain.Transactions;
using TechXplore.Domain.Users;

namespace TechXplore.API.Infrastructure.Mapping
{
    public static class MapsterConfiguration
    {
        public static void RegisterMaps(this IServiceCollection services)
        {
            TypeAdapterConfig<TransactionResponseModel, Transaction>
                .NewConfig()
                .TwoWays();

            TypeAdapterConfig<TransactionPostModel, Transaction>
                .NewConfig()
                .TwoWays();

            TypeAdapterConfig<LimitPostModel, Limit>
                .NewConfig()
                .TwoWays();

            TypeAdapterConfig<LimitResponseModel, Limit>
                .NewConfig()
                .TwoWays();

            TypeAdapterConfig<UserResponseModel, User>
                .NewConfig()
                .TwoWays();

            TypeAdapterConfig<UserRequestPostModel, User>
                .NewConfig()
                .TwoWays();

            TypeAdapterConfig<UserRequestPostModel, UserResponseModel>
                .NewConfig()
                .TwoWays();

            TypeAdapterConfig<CategoryResponseModel, Category>
                .NewConfig()
                .TwoWays();

            TypeAdapterConfig<RentResponseModel, Rent>
                .NewConfig()
                .TwoWays();

            TypeAdapterConfig<RentPostModel, Rent>
                .NewConfig()
                .TwoWays();
        }
    }
}
