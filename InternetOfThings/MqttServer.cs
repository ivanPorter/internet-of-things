using System;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using MQTTnet;
using MQTTnet.Server;

namespace InternetOfThings
{
    public class MqttServer
    {
        static MqttFactory factory = new MqttFactory();
        IMqttServer server;
        IMqttServerOptions options;
        public MqttServer(System.Net.IPAddress iPAddress, int port)
        {
            server = factory.CreateMqttServer();
            options = new MqttServerOptionsBuilder() 
                .WithDefaultEndpointBoundIPAddress(iPAddress)
                .WithDefaultEndpointPort(port)
                .WithApplicationMessageInterceptor(OnMessage)
                .Build();
        }

        public void OnMessage(MqttApplicationMessageInterceptorContext message)
        {
            var payload = Encoding.UTF8.GetString(message.ApplicationMessage.Payload);
            Console.WriteLine(payload);
        }
        public Task StartAsync()
        {
            return server.StartAsync(options);
        }

        public static async Task<int> Run(ServerOptions options){
            MqttServer server = new MqttServer(IPAddress.Parse(options.IpAddress), options.Port);
            await server.StartAsync();
            Console.ReadLine();
            return 0;
        }
    }
}
