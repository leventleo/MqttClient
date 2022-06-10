using MQTTnet;
using MQTTnet.Client;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace MqttClient
{
    class Program
    {
        static async  Task Main(string[] args)
        {

            var mqttFactory = new MqttFactory();

            using (var mqttClient = mqttFactory.CreateMqttClient())
            {
                var mqttClientOptions = new MqttClientOptionsBuilder()
                    .WithTcpServer("127.0.0.1")
                    .Build();

                 await mqttClient.ConnectAsync(mqttClientOptions, CancellationToken.None);

                var applicationMessage = new MqttApplicationMessageBuilder()
                    .WithTopic("samples/temperature/living_room")
                    .WithPayload("19.5")
                    .Build();

                  await mqttClient.PublishAsync(applicationMessage, CancellationToken.None);

                Console.WriteLine("MQTT application message is published.");
            }

        }
    }
 
}
