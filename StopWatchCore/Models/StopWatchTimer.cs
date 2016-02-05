using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StopWatchCore.Models
{
    public class StopWatchTimer : IStopWatchTimer
    {
        private TimeSpan _startTime;
        private DateTime _stopTime;


        private StopWatchState _stateTimer;
        public StopWatchState StateTimer
        {
            get
            {
                if (_startTime.TotalMilliseconds == 0)
                    return StopWatchState.Idle;
                else
                    return _stateTimer;
            }
            set { _stateTimer = value; }


        }


        private TimeSpan _paused;
        public TimeSpan Paused
        {
            get
            {
                return _paused;
            }
            set
            {

                if (value > TimeSpan.Zero)
                    _paused = DateTime.Now.AddMilliseconds(_startTime.TotalMilliseconds) - _stopTime;

                _paused = value;
            }
        }

        public TimeSpan GetCurrentTimeTimer()
        {
            if (StateTimer == StopWatchState.Running)
            {
                var ret = DateTime.Now.AddMilliseconds(_startTime.TotalMilliseconds) - DateTime.Now;
                _startTime = ret;

                return ret;
            }
            else if (StateTimer == StopWatchState.Paused)
                return Paused;
            else
                return new TimeSpan(0, 0, 0, 0);
        }

        public void Start(TimeSpan input)
        {
            if (input.TotalMilliseconds > 0)
            {
                _stateTimer = StopWatchState.Running;
                _startTime = input;
            }
            else
            {
                _startTime = TimeSpan.Zero;
                _stateTimer = StopWatchState.Idle;
            }
        }

        public void Stop()
        {
            _stopTime = DateTime.Now;
        }
    }
}
