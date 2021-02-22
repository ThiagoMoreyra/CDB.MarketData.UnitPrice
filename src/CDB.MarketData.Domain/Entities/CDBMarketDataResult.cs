using System;
using System.Collections.Generic;
using System.Text;

namespace CDB.MarketData.Domain.Entities
{
    public class CDBMarketDataResult
    {
        public DateTime Date { get; set; }
        public decimal UnitPrice { get; set; }
    }
}
