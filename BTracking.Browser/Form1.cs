using HiveMQtt.Client.Events;
using Microsoft.Web.WebView2.Core;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace BTracking.Browser
{
    public partial class Form1 : Form
    {

        public static Form1 form1 { get; set; }

        public Form1()
        {
            form1 = this;
            InitializeComponent();

            viewMonthly.EnsureCoreWebView2Async(null);
            viewMonthly.NavigationCompleted += viewMonthly_NavigationCompleted;

        }

        private async void viewMonthly_NavigationCompleted(object? sender, CoreWebView2NavigationCompletedEventArgs e)
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

            var mk = await this.viewMonthly.ExecuteScriptAsync(jsq);
            var mmk = mk.ToString().Substring(1).Substring(0, mk.Length - 2).Replace("\\\"", "\"");

            var jsn = JsonConvert.DeserializeObject<string[]>(mmk);
            var datas = jsn.Select(a => $"https://tr.investing.com{a}-historical-data").ToArray();

            var commands = new string[] {
            @"
document.getElementsByClassName('historical-data-v2_selection-arrow__3mX7U')[0].click();
setTimeout(function(){  
    document.getElementsByClassName('historical-data-v2_selection-arrow__3mX7U')[0].getElementsByClassName('historical-data-v2_menu-row__oRAlf')[2].click();
}, 500);
",

@"
var res = [['date','now', 'open', 'high','low','cap']];
var table = document.getElementsByTagName('table')[0];
for (var i = 1, row; row = table.rows[i]; i++) {
   res.push([ 
       row.cells[0].innerText, 
       parseFloat(row.cells[1].innerText.replace(',', '.')),
       parseFloat(row.cells[2].innerText.replace(',', '.')),
       parseFloat(row.cells[3].innerText.replace(',', '.')),
       parseFloat(row.cells[4].innerText.replace(',', '.')),
       row.cells[5].innerText
      ]);
}
JSON.stringify(res);"
        };

            Parallel.ForEach(datas, new ParallelOptions { MaxDegreeOfParallelism = 10 }, data =>
            {
                new BrowserBase().GetContent(commands, data);
            });

        }

        private async void Form1_Load(object sender, EventArgs e)
        {

        }

        public void NavigateMonthly(string value)
        {

            if (InvokeRequired)
            {
                this.Invoke(new Action<string>(NavigateMonthly), new object[] { value });
                return;
            }
            this.viewMonthly.CoreWebView2.Navigate(value);

        }

        private void viewMonthly_Click(object sender, EventArgs e)
        {
            this.viewMonthly.CoreWebView2.Navigate(null);
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}