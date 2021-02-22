using CDB.MarketData.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CDB.MarketData.Domain.Utils
{
    public static class CalcCDBPosFixed
    {

        public static IEnumerable<CDBMarketDataResult> GetUnitPriceList(double cdbRate, DateTime investmentDate, DateTime currentDate)
        {
            List<CDBMarketDataResult> resultList = new List<CDBMarketDataResult>();

            cdbRate /= 100;
            var pu = 1000.0;

            var cdiMarketData = CDIMarketData.GetCDIByInvestmentDate(investmentDate, currentDate).ToList();

            foreach (var item in cdiMarketData)
            {
                pu = GetUnitPrice(cdbRate, pu, item.GetLastTradePrice());
                resultList.Add(new CDBMarketDataResult { UnitPrice = (decimal)pu, Date = item.GetDate() });
            }

            return resultList;
        }

        public static double GetUnitPrice(double cdbRate, double pu, double lastTradePrice)
        {
            pu += Math.Round((pu * ((double)GetCDIDaily(lastTradePrice) * cdbRate)), 15);
            return pu;
        }

        public static decimal GetCDIDaily(double cdi)
        {
            cdi = cdi / 100 + 1;

            return (decimal)Math.Round((Math.Pow(cdi, (double)1 / 252) - 1), 8);
        }
    }
}
