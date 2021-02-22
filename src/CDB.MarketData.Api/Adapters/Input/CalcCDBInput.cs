using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CDB.MarketData.Api.Adapters.Input
{
    public class CalcCDBInput
    {
        public DateTime InvestmentDate { get; set; }
        public double CdbRate { get; set; }
        public DateTime CurrentDate { get; set; }
    }
}
