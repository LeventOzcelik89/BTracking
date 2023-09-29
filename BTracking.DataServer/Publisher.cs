using MQTTnet;
using MQTTnet.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTracking.DataServer
{

    public class Publisher
    {
        public static string _topic => "btracking/finance/update";
        public static string _server => _server;

        public static async Task Publish(string message)
        {
            /*
             * This sample pushes a simple application message including a topic and a payload.
             *
             * Always use builders where they exist. Builders (in this project) are designed to be
             * backward compatible. Creating an _MqttApplicationMessage_ via its constructor is also
             * supported but the class might change often in future releases where the builder does not
             * or at least provides backward compatibility where possible.
             */

            var mqttFactory = new MqttFactory();

            using (var mqttClient = mqttFactory.CreateMqttClient())
            {
                var mqttClientOptions = new MqttClientOptionsBuilder()
                    .WithTcpServer(_server)
                    .Build();

                await mqttClient.ConnectAsync(mqttClientOptions, CancellationToken.None);

                var applicationMessage = new MqttApplicationMessageBuilder()
                    .WithTopic(_topic)
                    .WithPayload(message)
                    .Build();

                await mqttClient.PublishAsync(applicationMessage, CancellationToken.None);

                await mqttClient.DisconnectAsync();

                Console.WriteLine("MQTT application message is published.");
            }
        }

        public static async Task PublishMultiple(string message)
        {
            /*
             * This sample pushes multiple simple application message including a topic and a payload.
             *
             * See sample _Publish_Application_Message_ for more details.
             */

            var mqttFactory = new MqttFactory();

            using (var mqttClient = mqttFactory.CreateMqttClient())
            {
                var mqttClientOptions = new MqttClientOptionsBuilder()
                    .WithTcpServer(_server)
                    .Build();

                await mqttClient.ConnectAsync(mqttClientOptions, CancellationToken.None);

                var applicationMessage = new MqttApplicationMessageBuilder()
                    .WithTopic(_topic)
                    .WithPayload(message)
                    .Build();

                await mqttClient.PublishAsync(applicationMessage, CancellationToken.None);

                applicationMessage = new MqttApplicationMessageBuilder()
                    .WithTopic(_topic)
                    .WithPayload(message)
                    .Build();

                await mqttClient.PublishAsync(applicationMessage, CancellationToken.None);

                applicationMessage = new MqttApplicationMessageBuilder()
                    .WithTopic(_topic)
                    .WithPayload(message)
                    .Build();

                await mqttClient.PublishAsync(applicationMessage, CancellationToken.None);

                await mqttClient.DisconnectAsync();

                Console.WriteLine("MQTT application message is published.");
            }
        }

    }

}

