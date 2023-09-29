using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HiveMQtt;
using HiveMQtt.Client.Options;
using HiveMQtt.Client;
using HiveMQtt.MQTT5.ReasonCodes;
using System.Diagnostics;
using HiveMQtt.MQTT5.Types;
using System.Text.Json;
using Newtonsoft.Json;

namespace BTracking.DataBroker
{
    public static class Publisher
    {
        public static string _topic => "btracking/finance/update";
        public static string _server => "broker.hivemq.com";
        private static HiveMQClientOptions _options => new HiveMQClientOptions
        {
            Host = "b47f143796b34722a4bd279d6d62f372.s1.eu.hivemq.cloud",
            Port = 8883,
            UseTLS = true,
            UserName = "LeventOzcelik",
            Password = "Levent1125!"
        };

        private static HiveMQClient _client { get; set; }
        private static HiveMQClient GetClient()
        {
            lock (_client)
            {
                if (_client == null)
                {
                    _client = new HiveMQClient(_options);
                }
            }

            return _client;
        }



        public static async Task Publish(string message)
        {
            try
            {
                var conRes = await GetClient().ConnectAsync().ConfigureAwait(false);
                if (conRes.ReasonCode == ConnAckReasonCode.Success)
                {
                    Debug.WriteLine("MQTT Connected");
                }
                else
                {
                    Debug.Write("MQTT Connect Fail");
                    Environment.Exit(-1);
                }

                var msg = JsonConvert.SerializeObject(message);
                var publishResult = await GetClient().PublishAsync(_topic, msg, QualityOfService.AtLeastOnceDelivery).ConfigureAwait(false);

            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

    }
}
