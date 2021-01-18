using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace InternetOfThings
{
    public class MockObject
    {
        public static async Task<int> Run(MockObjectOptions options)
        {
            var client = new MqttClient(options.IpAddress, options.Port);
            await client.ConnectAsync();

            if (!ItemsUnique(options.SensorNames)){
                throw new Exception("SensorNames not distinct.");
            }
            while (true)
            {
                foreach (var sensorName in options.SensorNames)
                {
                    var payload = Sensor.RandomPayload(sensorName);
                    await client.SendPayload(payload);
                    Console.WriteLine(payload);
                }
                await Task.Delay(TimeSpan.FromSeconds(1.0));
            }
        }

        static bool ItemsUnique<T>(IEnumerable<T> values) => 
            values.Count() == values.Distinct().Count();
    }
}