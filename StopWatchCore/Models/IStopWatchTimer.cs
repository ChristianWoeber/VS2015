using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StopWatchCore.Models
{
    public interface IStopWatchTimer
    {
        StopWatchState StateTimer { get; }

        void Start(TimeSpan input);
        void Stop();
        TimeSpan GetCurrentTimeTimer();
    }
}
