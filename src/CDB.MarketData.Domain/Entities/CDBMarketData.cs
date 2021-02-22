using CDB.MarketData.Domain.Utils;
using System;
using System.Collections.Generic;

namespace CDB.MarketData.Domain.Entities
{
    public class CDBMarketData
    {
        public CDBMarketData(DateTime investmentDate, double cdbRate, DateTime currentDate)
        {
            InvestmentDate = investmentDate;
            CdbRate = cdbRate;
            CurrentDate = currentDate;
        }

        private DateTime InvestmentDate { get; set; }
        private double CdbRate { get; set; }
        private DateTime CurrentDate { get; set; }

        public IEnumerable<CDBMarketDataResult> GetUnitPriceList()
        {            
            return CalcCDBPosFixed.GetUnitPriceList(this.CdbRate, this.InvestmentDate, this.CurrentDate);            
        }

        public bool CdbRateIsValid()
        {
            return this.CdbRate > 0;
        }
    }
}
