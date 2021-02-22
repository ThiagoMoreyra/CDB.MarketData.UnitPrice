using CDB.MarketData.Domain.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace CDB.MarketData.Tests.Entities
{
    [TestClass]
    public class CDIMarketDataTests
    {
        [TestMethod]
        public void Retorna_false_cdi_market_data_security_name_preenchido()
        {
            var cdiMarketData = new CDIMarketData(string.Empty, "14/11/2016", 13.34);
            Assert.IsFalse(cdiMarketData.IsValid());
        }

        [TestMethod]
        public void Retorna_false_cdi_market_data_last_trade_price_maior_que_zero()
        {
            var cdiMarketData = new CDIMarketData("CDI", "14/11/2016", -1);
            Assert.IsFalse(cdiMarketData.IsValid());
        }
    }
}
