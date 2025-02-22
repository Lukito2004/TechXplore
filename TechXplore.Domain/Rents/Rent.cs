using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechXplore.Domain.Rents
{
    public class Rent
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public decimal InitialElectricityRent { get; set; }
        public decimal InitialGasRent { get; set; }
        public decimal GasPayed { get; set; }
        public decimal ElectricityPaid { get; set; }
        public int Month { get; set; }
        public int Year { get; set; }

    }
}
