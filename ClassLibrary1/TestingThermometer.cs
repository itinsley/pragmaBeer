using System;
using System.Collections.Generic;
using System.Text;
using PragmaBeer;

namespace PragmaBeer.TestUtilities
{
    /// <summary>
    /// Designed for integration testing. It will provide a sequence of static readings
    /// Once all readings have been read it will throw an exception
    /// </summary>
    public class TestingThermometer: IThermometer
    {
        Queue<double> temperatures = new Queue<double>();

        /// <summary>
        /// Initialise an instance with a guid and seed data
        /// </summary>
        /// <param name="guid">Unique ID to identify the Thermometer</param>
        /// <param name="seedData">Seed data to read from - i.e. "4,4.5,5,6"</param>
        public TestingThermometer(String guid, string seedData)
        {
            Guid = guid; //Change to guid
            string[] temperaturesArray = seedData.Split(",");
            for(int i=0; i<temperaturesArray.Length;i++ ) {
                temperatures.Enqueue(Convert.ToDouble(temperaturesArray[i]));
            }
        }

        public string Guid { get; }
        public double Temperature() {
            return temperatures.Dequeue();
        }
 
    }
}
