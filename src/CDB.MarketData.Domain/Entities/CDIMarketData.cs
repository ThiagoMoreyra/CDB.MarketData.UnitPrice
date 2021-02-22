using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;

namespace CDB.MarketData.Domain.Entities
{
    public class CDIMarketData
    {
        private static IEnumerable<CDIMarketData> _cdiContent;

        public CDIMarketData(string securityName, ReadOnlySpan<char> date, double lastTradePrice)
        {
            DateTime dateInvestment;
            DateTime.TryParse(date, out dateInvestment);//Realizando o parse pois o arquivo no azure está como readonly
            SecurityName = securityName;
            Date = dateInvestment;
            LastTradePrice = lastTradePrice;
        }

        private string SecurityName { get; set; }
        private DateTime Date { get; set; }
        private double LastTradePrice { get; set; }

        public DateTime GetDate()
        {
            return this.Date;
        }

        public double GetLastTradePrice()
        {
            return this.LastTradePrice;
        }

        public static IEnumerable<CDIMarketData> CDICollectionContent()
        {
            return _cdiContent;
        }

        public bool IsValid()
        {
            return SecurityNameIsValid() && LastTradePriceValidation();
        }

        private bool SecurityNameIsValid()
        {
            return !String.IsNullOrEmpty(this.SecurityName);
        }
        private bool LastTradePriceValidation()
        {
            return this.LastTradePrice > 0;
        }

        public static void LoadCDIValues(string path)
        {
            _cdiContent = File.ReadAllLines(path).Skip(1)
                .Select(a => a.Split(','))
                .Select(c => new CDIMarketData(
                    c[0],
                    c[1],
                    Double.Parse(c[2], CultureInfo.InvariantCulture)
                ));
        }

        public static IList<CDIMarketData> GetCDIByInvestmentDate(DateTime investmentDate, DateTime currentDate)
        {
            return _cdiContent
                        .Where(x => x.Date.Date >= investmentDate.Date
                        && x.Date.Date < currentDate.Date)
                        .OrderBy(x => x.Date).ToList();
        }
    }
}
