using CDB.MarketData.Domain.Entities;
using System;
using System.Collections.Generic;

namespace CDB.MarketData.Domain.Interfaces
{
    public interface IServiceCDBMarketData
    {
        IList<object> GetUnitPriceList(DateTime investmentDate, double cdbRate, DateTime currentDate);
    }
}
