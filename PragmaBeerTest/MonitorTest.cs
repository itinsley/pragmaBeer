using System;
using Xunit;
using PragmaBeer;

namespace PragmaBeerTest
{
    public class MonitorTest
    {
        [Fact]
        public void ValidTemp()
        {
            IThermometer thermometer = new StubThermometer();
            ContainerType Pilsner = new ContainerType(1, 4, 6, "Pilsner");
            Monitor monitor = new Monitor(thermometer, Pilsner);
            monitor.check();
        }
    }

    public class StubThermometer : IThermometer
    {
        public int Id { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public decimal Temperature { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    }
}
