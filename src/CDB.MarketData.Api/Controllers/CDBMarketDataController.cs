using CDB.MarketData.Api.Adapters.Input;
using CDB.MarketData.Api.Filter;
using CDB.MarketData.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CDB.MarketData.Api.Controllers
{
    [Route("v1/unitprice")]
    [ApiController]
    public class CDBMarketDataController : ControllerBase
    {
        private readonly IServiceCDBMarketData _serviceCDBMarketData;
        public CDBMarketDataController(IServiceCDBMarketData serviceCDBMarketData)
        {
            _serviceCDBMarketData = serviceCDBMarketData;
        }

        // GET: api/<CDBMarketDataController>
        [ValidateModel]
        [HttpGet]
        public IActionResult Get([FromQuery] CalcCDBInput calcCDBInput)
        {
            var result = _serviceCDBMarketData.GetUnitPriceList(calcCDBInput.InvestmentDate, calcCDBInput.CdbRate, calcCDBInput.CurrentDate);
            return Ok(result);
        }
    }
}
