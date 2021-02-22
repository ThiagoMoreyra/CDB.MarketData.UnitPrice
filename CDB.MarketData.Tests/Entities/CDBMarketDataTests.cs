using CDB.MarketData.Domain.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace CDB.MarketData.Tests.Entities
{
    [TestClass]
    public class CDBMarketDataTests
    {
        [TestMethod]
        public void Retorna_falso_cdbrate_menor_que_zero()
        {
            var marketData = new CDBMarketData(new DateTime(2016, 11, 14), -1, new DateTime(2016, 12, 26));            
            Assert.IsFalse(marketData.CdbRateIsValid());
        }

        [TestMethod]
        public void Retorna_falso_cdbrate_maior_que_zero()
        {
            var marketData = new CDBMarketData(new DateTime(2016, 11, 14), -1, new DateTime(2016, 12, 26));
            Assert.IsFalse(marketData.CdbRateIsValid());
        }

        [TestMethod]
        public void Retorna_verdadeiro_cdbrate_maior_que_zero()
        {
            var marketData = new CDBMarketData(new DateTime(2016, 11, 14), 103.7, new DateTime(2016, 12, 26));
            Assert.IsTrue(marketData.CdbRateIsValid());
        }       
    }
}
