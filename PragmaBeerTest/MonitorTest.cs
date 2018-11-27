using System;
using Xunit;
using PragmaBeer;

namespace PragmaBeerTest
{
    public class MonitorTest
    {
        [Fact]
        public void CorrectTemp()
        {
            ContainerType Pilsner = new ContainerType(1, 4, 6, "Pilsner");
            IThermometer thermometer = new StubThermometer(1, 4.1);
            Monitor monitor = new Monitor(thermometer, Pilsner);
            TemperatureReading reading = monitor.Check();
            Assert.Equal(thermometer.Temperature, reading.Temperature);
        }

        [Fact]
        public void GoodTemp()
        {
            ContainerType Pilsner = new ContainerType(1, 4, 6, "Pilsner");
            IThermometer thermometer = new StubThermometer(1, 4.1);
            Monitor monitor = new Monitor(thermometer, Pilsner);
            TemperatureReading reading = monitor.Check();
            Assert.Equal(thermometer.Temperature, reading.Temperature);
            Assert.Equal(TemperatureStatus.Good, reading.Status);
        }
        [Fact]
        public void FailingTemp_Over()
        {
            ContainerType Pilsner = new ContainerType(1, 4, 6, "Pilsner");
            IThermometer thermometer = new StubThermometer(1, 6.01);
            Monitor monitor = new Monitor(thermometer, Pilsner);
            TemperatureReading reading = monitor.Check();
            Assert.Equal(TemperatureStatus.Over, reading.Status);
        }
        [Fact]
        public void FailingTemp_Under()
        {
            ContainerType Pilsner = new ContainerType(1, 4, 6, "Pilsner");
            IThermometer thermometer = new StubThermometer(1, 3.99);
            Monitor monitor = new Monitor(thermometer, Pilsner);
            TemperatureReading reading = monitor.Check();
            Assert.Equal(TemperatureStatus.Under, reading.Status);
        }
    }

    public class StubThermometer : IThermometer
    {
        public StubThermometer(int id, double temperature)
        {
            Id = id;
            Temperature = temperature;
        }

        public int Id { get;}
        public double Temperature { get; }
    }
}
