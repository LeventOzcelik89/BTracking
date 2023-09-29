using BTracking.FNC.FinanceDailyData;
using BTracking.UT.Cities;
using Microsoft.Web.WebView2.Core;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BTracking.Browser
{

    public enum RunStep
    {
        Start = 0,
        GetDaily = 1,
        Stop = 2
    }

    public partial class DailyData : Form
    {
        private readonly IFinanceDailyDataRepository _financeDailyDataRepository;
        

        private RunStep _step = RunStep.Start;
        private List<string> _stocks { get; set; }

        public DailyData(IFinanceDailyDataRepository financeDailyDataRepository)
        {
            InitializeComponent();
            browser.EnsureCoreWebView2Async(null);
            browser.NavigationCompleted += browser_NavigationCompleted;
            _financeDailyDataRepository = financeDailyDataRepository;
        }

        private async void browser_NavigationCompleted(object? sender, CoreWebView2NavigationCompletedEventArgs e)
        {

            switch (_step)
            {
                case RunStep.Start:
                    {
                        var jsq = @"
var res = [];
var table = document.getElementsByClassName('crossRatesTbl')[0];
for (var i = 1, row; row = table.rows[i]; i++) {
    var hrf = row.cells[1].innerHTML;
    hrf = hrf.substr(hrf.indexOf('href=""') + 6);
    hrf = hrf.substr(0, hrf.indexOf('"">'))
    res.push(hrf);
}
JSON.stringify(res);";

                        var getBrowserData = await browser.ExecuteScriptAsync(jsq);
                        getBrowserData = getBrowserData.ToString().Substring(1).Substring(0, getBrowserData.Length - 2).Replace("\\\"", "\"");

                        var browserData = JsonConvert.DeserializeObject<string[]>(getBrowserData);
                        _stocks = browserData.Select(a => $"https://tr.investing.com{a}-historical-data").ToList();

                        _step = RunStep.GetDaily;
                        browser.CoreWebView2.Navigate(_stocks.FirstOrDefault());
                        _stocks.RemoveAt(0);
                    }

                    break;
                case RunStep.GetDaily:
                    {
                        var jsq = @"
var res = [];
var table = document.getElementsByTagName('table')[0];
for (var i = 1, row; row = table.rows[i]; i++) {
   res.push({ 
       date: row.cells[0].innerText, 
       now: parseFloat(row.cells[1].innerText.replace(',', '.')),
       open: parseFloat(row.cells[2].innerText.replace(',', '.')),
       high: parseFloat(row.cells[3].innerText.replace(',', '.')),
       low: parseFloat(row.cells[4].innerText.replace(',', '.')),
       cap: row.cells[5].innerText
      });
}
JSON.stringify(res);";

                        var getBrowserData = await browser.ExecuteScriptAsync(jsq);
                        getBrowserData = getBrowserData.ToString().Substring(1).Substring(0, getBrowserData.Length - 2).Replace("\\\"", "\"");
                        var name = await browser.ExecuteScriptAsync("document.getElementsByTagName('title')[0].innerText.replace(' Geçmiş Fiyatları - Investing.com', '')");
                        name = name.Substring(1).Substring(0, name.Length - 2).Replace("\\\"", "\"");

                        var symbol = (name.Split('(')[1].Replace(")", "")).Trim();
                        name = name.Replace($"({symbol})", "").Trim();

                        var dataRow = JsonConvert.DeserializeObject<List<InvestmentDataRow>>(getBrowserData);
                        var data = new InvestmentData { stockName = name, stockSymbol = symbol, DataRows = dataRow };

                        //_financeDailyDataAppService.CreateAsync(dataRow.FirstOrDefault());

                    }
                    break;
                case RunStep.Stop:

                    break;
                default:
                    break;
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            browser.CoreWebView2.Navigate("https://tr.investing.com/equities/trending-stocks");
        }
    }
}
