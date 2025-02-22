using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechXplore.Domain.Limits;
using TechXplore.Domain.Rents;
using TechXplore.Domain.Transactions;

namespace TechXplore.Domain.Users
{
    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public decimal Money { get; set; }
        public decimal ESGScore { get; set; }

        // Navigation Properties
        public IEnumerable<Transaction> Transactions { get; set; }
        public IEnumerable<Limit> Limits { get; set; }
        public IEnumerable<Rent> Rents { get; set; }
    }
}
