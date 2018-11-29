using System;
using System.Collections.Generic;
using System.Text;
using PragmaBeer;

namespace PragmaBeerTest
{
    public class StubThermometer : IThermometer
    {

        private double _temperature;
        public StubThermometer(int id, double temperature)
        {
            Id = id;
            _temperature = temperature;
        }

        public int Id { get; }
        public double Temperature() { return _temperature; }
    }
}
