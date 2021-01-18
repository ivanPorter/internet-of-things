using System.Threading.Tasks;
using System.Net;
using MQTTnet;
using MQTTnet.Client;
using MQTTnet.Client.Options;
using static MQTTnet.Protocol.MqttQualityOfServiceLevel;

namespace InternetOfThings
{
    public class MqttClient
    {
        static MqttFactory factory = new MqttFactory();
        IMqttClient client;
        IMqttClientOptions options;
        public MqttClient(string ipAddress, int port)
        {
            client = factory.CreateMqttClient();
            options = new MqttClientOptionsBuilder()
                .WithClientId("sensor-controller")
                .WithTcpServer(ipAddress, port).Build();
        }

        public Task ConnectAsync()
        {
            return client.ConnectAsync(options);
        }

        public Task SendPayload(Payload payload)
        {
            return client.PublishAsync($"sensors/{payload.Name}", 
                Serializer.SerializePayLoad(payload), ExactlyOnce);
        }
    }
}
