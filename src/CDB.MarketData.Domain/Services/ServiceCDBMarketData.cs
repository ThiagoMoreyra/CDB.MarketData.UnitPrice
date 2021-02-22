using CDB.MarketData.Domain.Entities;
using CDB.MarketData.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace CDB.MarketData.Domain.Services
{
    public class ServiceCDBMarketData : IServiceCDBMarketData
    {
        public IList<object> GetUnitPriceList(DateTime investmentDate, double cdbRate, DateTime currentDate)
        {
            var cdbMarketData = new CDBMarketData(investmentDate, cdbRate, currentDate);

            List<object> result = new List<object>();

            var marketData = cdbMarketData.GetUnitPriceList().OrderBy(x => x.Date).ToList();
            marketData.ForEach(x =>
                    result.Add(new 
                    {
                        date = x.Date.ToString("yyyy-MM-dd"),
                        unitPrice = (x.UnitPrice/100).ToString("##.##", CultureInfo.InvariantCulture)
                    }));

            return result;
        }
    }
}
