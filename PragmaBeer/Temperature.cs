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

    public class Temperature
    {
        public Temperature(decimal reading, TemperatureStatus status)
        {
            Reading = reading;
            Status = status;
        }

        decimal Reading { get; }
        TemperatureStatus Status {get; }
    }
}
