using System;
using System.Collections.Generic;
using System.Text;

namespace PragmaBeer
{
    public class Monitor
    {
        readonly IThermometer _thermometer;
        readonly ContainerType _containerType;
        public Monitor(IThermometer thermometer, ContainerType containerType) {
            _thermometer = thermometer;
            _containerType = containerType;
        }

        public TemperatureReading Check() {
            double temperature = _thermometer.Temperature();
            TemperatureStatus temperatureStatus;
            
            if (temperature > _containerType.TempMax) {
                temperatureStatus = TemperatureStatus.Over;
            } else if (temperature < _containerType.TempMin) {
                temperatureStatus = TemperatureStatus.Under;
            } else {
                temperatureStatus = TemperatureStatus.Good;
            }

            TemperatureReading temperatureReading = new TemperatureReading(temperature, temperatureStatus, _containerType);
            return temperatureReading;
        }
    }
}
