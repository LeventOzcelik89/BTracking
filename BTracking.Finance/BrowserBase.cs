using Microsoft.Web.WebView2.Core;
using Microsoft.Web.WebView2.WinForms;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using static BTracking.Finance.Controllers.ProcessController;

namespace BTracking.Finance
{
    public class BrowserBase
    {

        private string[] _commands { get; set; }
        private WebView2 _viewer { get; set; }

        public async void GetContent<T>(string[] commands, string url, Delegate_MarketsLoaded? method = null)
        {
            this._commands = commands;
            this._viewer = new WebView2();

            ((System.ComponentModel.ISupportInitialize)_viewer).BeginInit();
            ((System.ComponentModel.ISupportInitialize)_viewer).EndInit();
            _viewer.EnsureCoreWebView2Async(null);
            _viewer.NavigationCompleted += new System.EventHandler<CoreWebView2NavigationCompletedEventArgs>((sender, e) => NavigationCompleteEvnt<T>(sender, e, method));
            _viewer.Source = new Uri(url);

        }

        private async void NavigationCompleteEvnt<T>(object? sender, CoreWebView2NavigationCompletedEventArgs e, Delegate_MarketsLoaded? method = null)
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

                //  Publisher.Publish(JsonConvert.SerializeObject(datastr));

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

    }
}
