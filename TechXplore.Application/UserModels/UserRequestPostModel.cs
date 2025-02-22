using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechXplore.Application.LimitModels;
using TechXplore.Application.TransactionModels;
using TechXplore.Domain.Limits;
using TechXplore.Domain.Rents;
using TechXplore.Domain.Transactions;

namespace TechXplore.Application.UserModels
{
    public class UserRequestPostModel
    {
        public string Username { get; set; }
        public decimal Money { get; set; }
        public decimal ESGScore { get; set; }

        // Navigation Properties
        public IEnumerable<TransactionPostModel> Transactions { get; set; }
        public IEnumerable<LimitPostModel> Limits { get; set; }
        //public IEnumerable<RentPostModel> Rents { get; set; }
        public IEnumerable<Rent> Rents { get; set; }

    }
}
