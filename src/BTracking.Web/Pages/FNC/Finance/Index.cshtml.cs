using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Threading.Tasks;

namespace BTracking.Web.Pages.UT.Finance
{
    public class IndexModel : PageModel
    {
        public async void OnGet()
        {
            await Publisher.Publish("RunMonthly");
        }

        //            var commands = new string[] {
        //            @"
        //document.getElementsByClassName('historical-data-v2_selection-arrow__3mX7U')[0].click();
        //setTimeout(function(){  
        //    document.getElementsByClassName('historical-data-v2_selection-arrow__3mX7U')[0].getElementsByClassName('historical-data-v2_menu-row__oRAlf')[2].click();
        //}, 500);
        //",

        //@"
        //var res = [];
        //var table = document.getElementsByTagName('table')[0];
        //for (var i = 1, row; row = table.rows[i]; i++) {
        //   res.push({ 
        //       date: row.cells[0].innerText, 
        //       now: parseFloat(row.cells[1].innerText.replace(',', '.')),
        //       open: parseFloat(row.cells[2].innerText.replace(',', '.')),
        //       high: parseFloat(row.cells[3].innerText.replace(',', '.')),
        //       low: parseFloat(row.cells[4].innerText.replace(',', '.')),
        //       cap: row.cells[5].innerText
        //      });
        //}
        //var result = { 
        //    stockName: document.getElementsByTagName('title')[0].innerText.replace(' Geçmiş Fiyatları - Investing.com', ''),
        //    DataRows: res
        //};
        //JSON.stringify(result);"
        //        };

        //            foreach (var stock in stocks)
        //            {
        //                new BrowserBase().GetContent<List<InvestmentData>>(commands, stock);
        //            }

        //        }

        //        public async Task<IActionResult> GetMonthly()
        //        {
        //            var commands = new string[] {
        //                @"
        //var res = [];
        //var table = document.getElementsByClassName('crossRatesTbl')[0];
        //for (var i = 1, row; row = table.rows[i]; i++) {
        //    var hrf = row.cells[1].innerHTML;
        //    hrf = hrf.substr(hrf.indexOf('href=""') + 6);
        //    hrf = hrf.substr(0, hrf.indexOf('"">'))
        //    res.push(hrf);
        //}
        //JSON.stringify(res);"
        //            };

        //            new BrowserBase().GetContent<string[]>(commands, "https://tr.investing.com/equities/trending-stocks", method);

        //            return "dnm";
        //        }

        //}



    }
}