using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechXplore.Domain.Categories;

namespace TechXplore.Domain.Transactions
{
    public class Transaction
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int CompanyId { get; set; }
        public decimal MoneySpent { get; set; }
        public DateTime TransactionTime { get; set; }
    }
}
