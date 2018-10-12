using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortTest
{
    public class Timing
    {
        TimeSpan duration;
        public Timing()
        {
            duration = new TimeSpan(0);
        }
        public void stopTime()
        {
            duration = Process.GetCurrentProcess().TotalProcessorTime;
        }
        public void startTime()
        {
            GC.Collect();
            GC.WaitForPendingFinalizers();
        }

        public TimeSpan Result()
        {
            return duration;
        }
    }
}
