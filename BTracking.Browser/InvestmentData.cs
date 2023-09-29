using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTracking.Browser
{
    public class InvestmentData
    {
        public string stockName { get; set; }
        public string stockSymbol { get; set; }
        public List<InvestmentDataRow> DataRows { get; set; }
    }

    public class InvestmentDataRow
    {
        public string date { get; set; }
        public double now { get; set; }
        public double open { get; set; }
        public double high { get; set; }
        public double low { get; set; }
        public string cap { get; set; }
        public DateTime _date
        {
            get
            {
                return DateTime.ParseExact(this.date, "dd.MM.yyyy", CultureInfo.InvariantCulture);
            }
        }
    }
}
