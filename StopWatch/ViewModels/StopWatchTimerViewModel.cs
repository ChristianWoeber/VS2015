using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StopWatchCore.Models;

namespace StopWatch.ViewModels
{
    public class StopWatchTimerViewModel
    {
        public StopWatchTimer _watch = new StopWatchTimer();

        public TimeSpan CurrentTimeTimer
        {
            get
            {
                return _watch.GetCurrentTime();
            }

        }

        public StopWatchState State
        {
            get
            {
                return _watch.State;

            }
        }

        public void Start(TimeSpan input)
        {
            _watch.Start(input);
        }

        public void Paused()
        {
            _watch.Paused();
        }

        public void Stop()
        {
            _watch.Stop();
        }
    }
}
