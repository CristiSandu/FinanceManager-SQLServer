using System;
using System.Collections.Generic;
using System.Text;

namespace FinanceManager.Models
{
    public class StatisticsModel
    {
        public DateTime Month { get; set; }
        public double Income { get; set; }
        public double Expences { get; set; }
        public double Sold { get; set; }
    }
}
