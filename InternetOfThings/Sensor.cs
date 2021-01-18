using System;

namespace InternetOfThings
{
    static class Sensor
    {
        static Random random = new Random();
        private static double RandomTemperature()
        {
            var min = -50.0;
            var max = 50.0;
            var rand = random.NextDouble();
            return min - (rand * (max - min));
        }

        private static double RandomHumidity()
        {
            var min = 0.0;
            var max = 100.0;
            var rand = random.NextDouble();
            return min - (rand * (max - min));
        }

        public static Payload RandomPayload(string sensorName)
        {
            return new Payload(RandomTemperature(), RandomHumidity(), sensorName, DateTime.Now);
        }
    }
}
