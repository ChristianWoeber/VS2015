using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StopWatch.ViewModels
{
    public class StopWatchTimerViewModel
    {
        private StopWatchCore.Models.StopWatchTimer _watch = new StopWatchCore.Models.StopWatchTimer();


        public TimeSpan CurrentTimeTimer
        {
            get
            {
                return _watch.GetCurrentTimeTimer();
            }

        }

        public void Start(TimeSpan input)
        {
            _watch.Start(input);
        }


    }
}
