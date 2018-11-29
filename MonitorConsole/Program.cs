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
            
            //Pilsner in Container Pragma1
            ContainerType Pilsner = new ContainerType(1, 4, 6, "Pilsner");
            IThermometer thermometerPragma1 = new TestingThermometer("Pragma1",
                "4,4,3.9,3.8,4,5,5.9,6,6.1");
            Monitor monitorPilsner = new Monitor(thermometerPragma1, Pilsner);

            //Ipa in Container Pragma2
            ContainerType Ipa = new ContainerType(1, 4, 6, "Ipa");
            IThermometer thermometerPragma2 = new TestingThermometer("Pragma2",
                "4.9,5,5,5,5.5,5.9,6,6.1");
            Monitor monitorIpa = new Monitor(thermometerPragma2, Ipa);

            List<Monitor> monitors = new List<Monitor>();
            monitors.Add(monitorPilsner);
            monitors.Add(monitorIpa);

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
            Console.WriteLine(reading.Description());
            if (reading.Status != TemperatureStatus.Good) {
                Console.WriteLine("******WARNING******");
            }
        }


    }
}
