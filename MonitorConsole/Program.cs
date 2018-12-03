using System;
using System.Collections.Generic;
using System.IO;
using PragmaBeer;
using PragmaBeer.TestUtilities;
using System.Diagnostics;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace MonitorConsole
{
    class Program
    {
        const int CheckIntervalSeconds = 2;
        static void Main(string[] args)
        {
            string filename = Directory.GetCurrentDirectory() + "\\config.json";
            string json = File.ReadAllText(filename);
            PragmaBeerConfig pragmaBeerConfig = JsonConvert.DeserializeObject<PragmaBeerConfig>(json);
            List<Monitor> monitors = new List<Monitor>();

            foreach (ContainerTypeConfig containerTypeConfig in pragmaBeerConfig.ContainerTypes){
                ContainerType containerType = new ContainerType(containerTypeConfig);
                //Add real thermometer reference here
                IThermometer stubThermometer = new TestingThermometer(containerTypeConfig.ThermometerGuid,
                    "4,4,3.9,3.8,4,5,5.9,6,6.1");
                Monitor monitor = new Monitor(stubThermometer, containerType);
                monitors.Add(monitor);
            }

            MonitorSchedule schedule = new MonitorSchedule(CheckIntervalSeconds, monitors);
            schedule.MonitorReadEvent += new EventHandler(MonitorSchedule__MonitorReadEvent);

            Console.WriteLine("{0:h:mm:ss.fff} Creating timer.\n", DateTime.Now);
            schedule.start();
            Console.ReadLine();
        }

        static void MonitorSchedule__MonitorReadEvent(object sender, EventArgs e)
        {
            TemperatureReadingEventArgs args = (TemperatureReadingEventArgs)e;
            TemperatureReading reading = args.Reading;
            Console.WriteLine(reading.Description());
            if (reading.Status != TemperatureStatus.Good) {
                Console.WriteLine("******WARNING******");
            }
        }


    }
}
