using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StopWatchCore.Models
{
    interface IStopWatch
    {
        StopWatchState State { get;}

        void Start();
        StopWatchItems Stop();
        TimeSpan GetCurrentTime();      
    }
}
