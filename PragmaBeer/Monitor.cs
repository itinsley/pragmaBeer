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

        public Temperature check() {
            throw new NotImplementedException();
        }
    }
}
