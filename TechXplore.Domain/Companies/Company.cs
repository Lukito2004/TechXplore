using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechXplore.Domain.Transactions;

namespace TechXplore.Domain.Companies
{
    public class Company
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int CategoryId { get; set; }
        public decimal ESGCoefficient { get; set; }
        public IEnumerable<Transaction> Transactions { get; set; }
    }
}
