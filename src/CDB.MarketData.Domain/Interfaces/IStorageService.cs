using CDB.MarketData.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CDB.MarketData.Domain.Interfaces
{
    public interface IStorageService
    {
        Task<IList<CDIMarketData>> Get(string fileName, string folder);
    }
}
