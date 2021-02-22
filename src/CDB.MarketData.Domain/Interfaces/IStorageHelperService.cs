using System.Threading.Tasks;

namespace CDB.MarketData.Domain.Interfaces
{
    public interface IStorageHelperService
    {
        Task<string> Get(string fileName, string folder);
    }
}
