using Mapster;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechXplore.Application.CategoryModels;
using TechXplore.Application.RentModels;
using TechXplore.Application.Repositories;
using TechXplore.Domain.Categories;
using TechXplore.Domain.Rents;

namespace TechXplore.Application.Services.Rents
{
    public class RentService : IRentService
    {
        private readonly IRentRepository _rentRepository;
        public RentService(IRentRepository rentRepository)
        {
            _rentRepository = rentRepository;
        }

        public async Task<IEnumerable<RentResponseModel>> GetAllRent(CancellationToken cancellationToken)
        {
            IEnumerable<Rent> rent = await _rentRepository.GetAllAsync(cancellationToken);
            return rent.Adapt<IEnumerable<RentResponseModel>>();
        }
        public async Task<RentResponseModel> GetRent(CancellationToken cancellationToken, int id)
        {
            Rent rent = await _rentRepository.Get(cancellationToken, id);
            return rent.Adapt<RentResponseModel>();
        }

        public async Task<RentResponseModel> GetRentByYearAndMonth(CancellationToken cancellationToken, int year, int month)
        {
            IEnumerable<Rent> rent = await _rentRepository.GetAllAsync(cancellationToken);
            rent.SingleOrDefault(x => x.Year == year && x.Month == month);
            return rent.Adapt<RentResponseModel>();
        }
    }
}
