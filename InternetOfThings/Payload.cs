using System;

namespace InternetOfThings
{
    public record Payload(double Temperature, double Humidity, string Name, DateTime Date);
}
