using Microsoft.Web.WebView2.Core;
using Microsoft.Web.WebView2.WinForms;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace BTracking.Browser
{
    public class BrowserBase : IDisposable
    {

        private string[] _commands { get; set; }
        private WebView2 _viewer { get; set; }
        private string _topic => "btracking/finance/dailyresult";

        public void GetContent(string[] commands, string url)
        {
            this._commands = commands;

            this._viewer = new WebView2();
            ((System.ComponentModel.ISupportInitialize)_viewer).BeginInit();
            ((System.ComponentModel.ISupportInitialize)_viewer).EndInit();
            _viewer.EnsureCoreWebView2Async(null);
            _viewer.NavigationCompleted += NavigationCompleteEvnt;
            _viewer.Source = new Uri(url);
        }

        private async void NavigationCompleteEvnt(object? sender, CoreWebView2NavigationCompletedEventArgs e)
        {
            try
            {

                string res = "";
                foreach (var com in _commands)
                {
                    res = await _viewer.ExecuteScriptAsync(com);
                    Thread.Sleep(1000);
                }

                var datastr = res.ToString().Substring(1).Substring(0, res.Length - 2).Replace("\\\"", "\"");
                //  var data = Newtonsoft.Json.JsonConvert.DeserializeObject<List<InvestmentDataRow>>(datastr);
                var name = await _viewer.ExecuteScriptAsync("document.getElementsByTagName('title')[0].innerText.replace(' Geçmiş Fiyatları - Investing.com', '')");
                name = name.Substring(1).Substring(0, name.Length - 2).Replace("\\\"", "\"");

                datastr = "{ \"stockName\" : \"" + name + "\", \"DataRows\" : " + datastr + " }";;

                //  mqtt publish
                await Publisher.Publish(datastr, _topic);
                this._viewer.Dispose();
                

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }

        public void Dispose()
        {
            this._viewer.Dispose();
            Thread.CurrentThread.Suspend();
        }
    }
}
