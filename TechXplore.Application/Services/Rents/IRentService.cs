using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechXplore.Application.LimitModels;
using TechXplore.Application.RentModels;

namespace TechXplore.Application.Services.Rents
{
    public interface IRentService
    {
        public Task<IEnumerable<RentResponseModel>> GetAllRent(CancellationToken cancellationToken);
        public Task<RentResponseModel> GetRent(CancellationToken cancellationToken, int id);
        public Task<RentResponseModel> GetRentByYearAndMonth(CancellationToken cancellationToken, int year, int month);
    }
}
