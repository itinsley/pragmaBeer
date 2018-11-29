using System;
using System.Collections.Generic;
using System.Text;
using PragmaBeer;

namespace PragmaBeerTest
{
    public class StubThermometer : IThermometer
    {

        private double _temperature;
        public StubThermometer(string guid, double temperature)
        {
            Guid = guid;
            _temperature = temperature;
        }

        public string Guid { get; }
        public double Temperature() { return _temperature; }
    }
}
