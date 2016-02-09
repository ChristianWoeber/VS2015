using System;

namespace StopWatchCore.Models
{
    public class StopWatchTimer : IStopWatchTimer
    {
        private TimeSpan _curTime;
        private DateTime _startTime;
        private DateTime _pausedStartTime;
        private DateTime _pausedEndTime;
        private TimeSpan _pausedDuration;
        private TimeSpan _input;

        public delegate void StopWatchChangedToIdleHandler(object source, EventArgs args);
        public event StopWatchChangedToIdleHandler StopWatchStateChangedToIdle;

        private StopWatchState _state;
        public StopWatchState State
        {
            get
            {
                if (_state == StopWatchState.Running && _curTime < TimeSpan.Zero)
                {
                    OnStopWatchStateChangedIdle();
                    return StopWatchState.Idle;
                }
                else
                    return _state;
            }
            set { _state = value; }
        }

        protected internal void OnStopWatchStateChangedIdle()
        {
            StopWatchStateChangedToIdle(this, EventArgs.Empty);
        }

        public TimeSpan CurrentTime
        {
            get
            {
                switch (State)
                {
                    case (StopWatchState.Running):
                        _curTime = _input - (DateTime.Now - _startTime);
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
                return TimeSpan.Zero;

        }

        public void Start(TimeSpan input)
        {
            if (input.TotalMilliseconds > 0 && _state != StopWatchState.Paused)
            {
                _state = StopWatchState.Running;
                _startTime = DateTime.Now;
                _curTime = _input = input;
            }
            else if (_state == StopWatchState.Paused)
            {
                _state = StopWatchState.Running;
                _pausedEndTime = DateTime.Now;
                _pausedDuration = _pausedEndTime - _pausedStartTime;
                input = _input = _curTime;
                _startTime = _pausedStartTime + _pausedDuration;
            }
            else if(_state == StopWatchState.Idle && _curTime < TimeSpan.Zero)
            {
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
            _pausedStartTime = DateTime.Now;

        }

        public void Stop()
        {
            _state = StopWatchState.Idle;
        }

    }
}
