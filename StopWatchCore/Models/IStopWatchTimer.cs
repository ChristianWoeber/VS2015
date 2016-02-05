using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StopWatchCore.Models
{
    public interface IStopWatchTimer
    {
        StopWatchState State { get; }

        void Start(TimeSpan input);
        void Paused();
        TimeSpan GetCurrentTime();
    }
}
