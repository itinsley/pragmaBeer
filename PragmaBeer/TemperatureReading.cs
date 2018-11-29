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
        public TemperatureReading(double temperature, TemperatureStatus status, ContainerType containerType)
        {
            Temperature = temperature;
            Status = status;
            ContainerType = containerType;
        }

        public double Temperature { get; }
        public TemperatureStatus Status {get; }
        public ContainerType ContainerType { get; }

        public string Description() {
            return string.Format(" - {0} - Temp: {1} - status: {2}", 
                ContainerType.Description,
                Temperature, 
                Status);
        }
    }
}
