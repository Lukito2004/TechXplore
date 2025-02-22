using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechXplore.Domain.Companies;
using TechXplore.Domain.Transactions;

namespace TechXplore.Domain.Categories
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public IEnumerable<Company> Companies { get; set; }
    }
}
