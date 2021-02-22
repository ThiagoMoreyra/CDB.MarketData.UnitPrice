using CDB.MarketData.Domain.Entities;
using System.Collections.Generic;

namespace CDB.MarketData.Domain.Interfaces
{
    public interface IServiceCalcCDB
    {
        IList<CDBMarketDataResult> GetUnitPriceList(CDBMarketData calcCDBInput);
    }
}
