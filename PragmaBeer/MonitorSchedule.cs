using System;
using System.Collections.Generic;
using System.Threading;
using System.Diagnostics;

namespace PragmaBeer
{

    public class MonitorSchedule
    {
        public int WaitInSeconds { get; }
        public List<Monitor>  Monitors {get;}

        public MonitorSchedule(int waitInSeconds, List<Monitor> monitors )
        {
            WaitInSeconds = waitInSeconds;
            Monitors = monitors;
        }
        private void CheckMonitors(Object stateInfo) {
            foreach (Monitor monitor in Monitors) {
                try {
                    TemperatureReading reading = monitor.Check();
                    Console.WriteLine(" - {0} - Temp: {1} - status: {2}", reading.ContainerType.Description,
                        reading.Temperature, reading.Status);
                }
                catch(Exception e){
                    Console.WriteLine("Unhandled exception occurred. Will continue monitoring. Details {0}", 
                        e.Message);
                }
            }
        }
        public void start() {
            Console.WriteLine("{0:h:mm:ss.fff} Creating timer.\n", DateTime.Now);
            var stateTimer = new Timer(CheckMonitors,null, 0, Wait());
        }

        public int Wait() {
            return WaitInSeconds * 1000;
        }
    }
}
