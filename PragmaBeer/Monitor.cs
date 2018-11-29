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
            TemperatureStatus temperatureStatus;
            if (_thermometer.Temperature() > _containerType.TempMax) {
                temperatureStatus = TemperatureStatus.Over;
            } else if (_thermometer.Temperature() < _containerType.TempMin) {
                temperatureStatus = TemperatureStatus.Under;
            } else {
                temperatureStatus = TemperatureStatus.Good;
            }

            TemperatureReading temperatureReading = new TemperatureReading(_thermometer.Temperature(), temperatureStatus);
            return temperatureReading;
        }
    }
}
