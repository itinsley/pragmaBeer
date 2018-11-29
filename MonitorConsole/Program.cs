using System;
using System.Collections.Generic;
using PragmaBeer;
using PragmaBeer.TestUtilities;
using System.Diagnostics;


namespace MonitorConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hit enter to exit");
            ContainerType Pilsner = new ContainerType(1, 4, 6, "Pilsner");
            IThermometer thermometerPragma1 = new TestingThermometer("Pragma1");
            Monitor monitorPilsner = new Monitor(thermometerPragma1, Pilsner);
            List<Monitor> monitors = new List<Monitor>();
            monitors.Add(monitorPilsner);

            MonitorSchedule schedule = new MonitorSchedule(2, monitors);
            schedule.MonitorReadEvent += new EventHandler(MonitorSchedule__MonitorReadEvent);

            Console.WriteLine("{0:h:mm:ss.fff} Creating timer.\n", DateTime.Now);
            schedule.start();
            Console.ReadLine();
        }

        static void MonitorSchedule__MonitorReadEvent(object sender, EventArgs e)
        {
            TemperatureReadingEventArgs args = (TemperatureReadingEventArgs)e;
            TemperatureReading reading = args.Reading;
            Console.WriteLine(" - {0} - Temp: {1} - status: {2}", reading.ContainerType.Description,
                reading.Temperature, reading.Status);
        }


    }
}
