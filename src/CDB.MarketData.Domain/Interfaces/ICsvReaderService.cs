using CDB.MarketData.Domain.Entities;
using System.Collections.Generic;

namespace CDB.MarketData.Domain.Interfaces
{
    public interface ICsvReaderService
    {
        IEnumerable<CDIMarketData> GetCsvData(string path);
    }
}
