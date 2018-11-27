using System;
using System.Collections.Generic;
using System.Text;

namespace PragmaBeer
{
    public enum TemperatureStatus {
        Over,
        Good,
        Under
    }

    public class TemperatureReading
    {
        public TemperatureReading(double temperature, TemperatureStatus status)
        {
            Temperature = temperature;
            Status = status;
        }

        public double Temperature { get; }
        public TemperatureStatus Status {get; }
    }
}
