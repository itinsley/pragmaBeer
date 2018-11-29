using System;
using System.Collections.Generic;
using System.Text;
using PragmaBeer;

namespace PragmaBeer.TestUtilities
{
    //Designed for integration testing. It will provide a sequence of static readings
    //Once all readings have been read it will throw an exception
    public class TestingThermometer: IThermometer
    {
        Queue<double> temperatures = new Queue<double>();
        string temperatureData = "4,4,4.1,4,3.9";

        public TestingThermometer(String guid)
        {
            Guid = guid; //Change to guid
            string[] temperaturesArray = temperatureData.Split(",");
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
