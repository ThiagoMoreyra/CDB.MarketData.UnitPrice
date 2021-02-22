using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CDB.MarketData.Api.Adapters.Output
{
    public class CalcCDBOutput
    {
        public DateTime Date { get; set; }
        public decimal UnitPrice { get; set; }
    }
}
