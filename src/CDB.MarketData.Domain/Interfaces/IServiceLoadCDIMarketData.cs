using CDB.MarketData.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CDB.MarketData.Domain.Interfaces
{
    public interface IServiceLoadCDIMarketData
    {
        Task<IList<CDIMarketData>> GetCDIMarketDataContent();
    }
}
