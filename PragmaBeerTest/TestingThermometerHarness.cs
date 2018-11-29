using System;
using Xunit;
using PragmaBeer;
using System.Collections.Generic;
using PragmaBeer.TestUtilities;


namespace PragmaBeerTest
{
    public class TestingThermometerHarness
    {
        [Fact]
        public void Sanity()
        {
            //This is a harness for testing the testingThermometer!
            string expected = "4,4,4.1,4,3.9";

            IThermometer thermometer = new TestingThermometer("therm1");
            List<double> temperatures = new List<double>();
            for (int i = 0; i < 5; i++)
            {
                temperatures.Add(thermometer.Temperature());
            }

            var result = String.Join(",", temperatures.ToArray());

            Assert.Equal(expected, result);
        }
    }
}
