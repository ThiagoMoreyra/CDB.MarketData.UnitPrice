using CDB.MarketData.Domain.Entities;
using CDB.MarketData.Domain.Services;
using CDB.MarketData.Domain.Utils;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;
using System.Linq;

namespace CDB.MarketData.Tests.Calc
{
    [TestClass]
    public class CalcCDBPosFixedTests
    {
        public CalcCDBPosFixedTests()
        {
            var baseDirectory = Path.Combine(AppDomain.CurrentDomain.BaseDirectory);
            CDIMarketData.LoadCDIValues(baseDirectory + "CDI_Prices.csv");
        }

        [TestMethod]
        public void Retorna_verdadeiro_CDI_Daily_Valido()
        {
            Assert.AreEqual(0.00051591M, CalcCDBPosFixed.GetCDIDaily(13.88));
        }

        [TestMethod]
        public void Retorna_verdadeiro_UnitPrice_Valido()
        {
            Assert.AreEqual(1053.396685M, (decimal)CalcCDBPosFixed.GetUnitPrice(103.5, 1000.0, 13.88));
        }

        [TestMethod]
        public void Retorna_verdadeiro_UnitPrice_Lista_Valida()
        {
            ServiceCDBMarketData serviceCDBMarketData = new ServiceCDBMarketData();
            Assert.AreEqual(CDIMarketData.GetCDIByInvestmentDate(new DateTime(2016, 11, 14), new DateTime(2016, 12, 26)).Count(),
                                                                    serviceCDBMarketData.GetUnitPriceList(new DateTime(2016, 11, 14), 103.5,
                                                                    new DateTime(2016, 12, 26)).Count());
        }
    }
}
