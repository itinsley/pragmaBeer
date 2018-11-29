using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading;

namespace PragmaBeer
{
    public class TemperatureReadingEventArgs : EventArgs
    {
        public TemperatureReading Reading { get; set; }
    }

    public class MonitorSchedule
    {
        public int WaitInSeconds { get; }
        public List<Monitor>  Monitors {get;}

        public ISynchronizeInvoke EventSyncInvoke { get; set; }
        public event EventHandler MonitorReadEvent;

        public MonitorSchedule(int waitInSeconds, List<Monitor> monitors )
        {
            WaitInSeconds = waitInSeconds;
            Monitors = monitors;
        }
        private void CheckMonitors(Object stateInfo) {
            foreach (Monitor monitor in Monitors) {
                try {
                    TemperatureReading reading = monitor.Check();
                    TemperatureReadingEventArgs eventArgs = new TemperatureReadingEventArgs();
                    eventArgs.Reading = reading;
                    RaiseMonitorReadEvent(eventArgs);
                }
                catch (Exception e){
                    //This is not ideal. Should raise separate event that something failed
                    //Don't want to let unhandled exception occur as some level of fail tolerance is required
                    //Beyond the scope of this work.
                    Console.WriteLine("Unhandled exception occurred. Will continue monitoring. Details {0}", 
                        e.Message);
                }
            }
        }
        public void start() {
            Console.WriteLine("{0:h:mm:ss.fff} Creating timer.\n", DateTime.Now);
            var stateTimer = new Timer(CheckMonitors,null, 0, Wait());
        }

        private void RaiseMonitorReadEvent(EventArgs e)
        {
            // Take a local copy -- this is for thread safety.
            EventHandler monitorReadEvent = this.MonitorReadEvent;

            // Check for no subscribers
            if (monitorReadEvent == null)
                return;

            if (EventSyncInvoke == null)
                monitorReadEvent(this, e);
            else
                EventSyncInvoke.Invoke(monitorReadEvent, new object[] { this, e });
        }


        public int Wait() {
            return WaitInSeconds * 1000;
        }
    }
}
