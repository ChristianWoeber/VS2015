using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StopWatchCore.Models
{
    public class StopWatchTimer : IStopWatchTimer
    {
        private TimeSpan _curTime;
        private DateTime _startTime;      
        private TimeSpan _paused;
        private TimeSpan _input;
        private bool _isPaused { get; set; }


        private StopWatchState _state;       
        public StopWatchState State
        {
            get
            {
                if (_curTime.TotalMilliseconds <= 0)
                    return StopWatchState.Idle;
                else
                    return _state;
            }
            set { _state = value; }
        }

        public TimeSpan CurrentTime
        {
            get
            {
                switch (State)
                {
                    case (StopWatchState.Running):
                        if (_isPaused)
                        {

                            _curTime = _input - (DateTime.Now - _startTime);
                            _isPaused = false;
                        }
                        else
                        {
                            _curTime = _input - (DateTime.Now - _startTime);
                        }
                        return (_curTime.TotalMilliseconds < 0)
                            ? TimeSpan.Zero
                            : _curTime;

                    default:
                        return TimeSpan.Zero;
                }
            }
        }

        public TimeSpan GetCurrentTime()
        {
            if (State == StopWatchState.Running)
                return CurrentTime;
            else if (State == StopWatchState.Paused)
                return TimeSpan.Zero;
            else
                return new TimeSpan(0, 0, 0, 0);

        }

        public void Start(TimeSpan input)
        {
            if (input.TotalMilliseconds > 0 && _isPaused == false)
            {
                _state = StopWatchState.Running;
                _startTime = DateTime.Now;
                _curTime = _input = input;
            }
            else if (input.TotalMilliseconds > 0 && _isPaused)
            {
                _state = StopWatchState.Running;
                _curTime = input;
            }
            else
            {
                _curTime = TimeSpan.Zero;
                _state = StopWatchState.Idle;
            }
        }

        public void Paused()
        {
            _state = StopWatchState.Paused;
            _paused = _curTime;
            _isPaused = true;
        }
    }
}
