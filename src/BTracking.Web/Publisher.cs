﻿using HiveMQtt.Client.Options;
using HiveMQtt.Client;
using HiveMQtt.MQTT5.ReasonCodes;
using HiveMQtt.MQTT5.Types;
using Newtonsoft.Json;
using System.Diagnostics;
using System.Threading.Tasks;
using System;

namespace BTracking.Web
{
    public static class Publisher
    {
        public static string _topic => "btracking/finance/runmonthly";
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
        private static object _lockObj { get; set; } = new object();
        private static HiveMQClient GetClient()
        {
            lock (_lockObj)
            {
                if (_client == null)
                {
                    _client = new HiveMQClient(_options);
                }
            }

            return _client;
        }

        public static async Task Publish(string message, string topic)
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
                var publishResult = await GetClient().PublishAsync(topic, msg, QualityOfService.AtLeastOnceDelivery).ConfigureAwait(false);

            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }

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
                Debug.WriteLine(ex);
            }

        }

    }
}
