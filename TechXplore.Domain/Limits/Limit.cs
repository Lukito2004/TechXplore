﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechXplore.Domain.Limits
{
    public class Limit
    {
        public int CategoryId { get; set; }
        public int UserId { get; set; }
        public decimal MoneyLimit { get; set; }
    }
}
