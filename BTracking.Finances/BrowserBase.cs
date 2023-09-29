using Microsoft.Web.WebView2.Core;
using Microsoft.Web.WebView2.WinForms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTracking.Finances
{
    public class BrowserBase
    {

        private string[] _commands { get; set; }
        private WebView2 _viewer { get; set; }

        public async void GetStocks(string[] commands, string url)
        {
            this._commands = commands;
            this._viewer = new WebView2();
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
                }

                var datastr = res.ToString().Substring(1).Substring(0, res.Length - 2).Replace("\\\"", "\"");
                var data = JsonConvert.DeserializeObject<T>(datastr);

                //if (method != null)
                //{
                //    method(new string[] { data });
                //}
                //else
                //{
                //    await Publisher.Publish(data);
                //}

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

    }
}
