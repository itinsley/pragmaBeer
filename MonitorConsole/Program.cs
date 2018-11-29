using System;
using System.Collections.Generic;
using PragmaBeer;
using PragmaBeerTest; //Change this!

namespace MonitorConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hit enter to exit");
            ContainerType Pilsner = new ContainerType(1, 4, 6, "Pilsner");
            IThermometer thermometer1001 = new TestingThermometer(1001);
            Monitor monitorPilsner = new Monitor(thermometer1001, Pilsner);
            List<Monitor> monitors = new List<Monitor>();
            monitors.Add(monitorPilsner);

            MonitorSchedule schedule = new MonitorSchedule(2, monitors);

            schedule.start();
            Console.ReadLine();
        }
    }
}
