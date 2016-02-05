using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StopWatchCore.Models
{
    public class StopWatch : IStopWatch
    {
        private DateTime _startTime;
        private DateTime _pausedStartTime;
        private TimeSpan _pausedDuration;
        private TimeSpan _currRet;
        private List<TimeSpan> _lstPausedDuration = new List<TimeSpan>();
        private DateTime _pausedEnd;
        private bool _reset;


        private StopWatchState _state;
        public StopWatchState State
        {
            get
            {
                if (_pausedStartTime > _startTime)
                    return _state;
                else if (_startTime > DateTime.MinValue)
                    return StopWatchState.Running;
                else if (_startTime == DateTime.MinValue)
                    return StopWatchState.Idle;
                else
                    return _state;

            }
            set
            {
                _state = value;
            }
        }

        public TimeSpan GetCurrentTime()
        {
            if (State == StopWatchState.Running)
            {
                if (!_reset && _pausedStartTime > DateTime.MinValue)
                {
                    _currRet = DateTime.Now - _startTime - _pausedDuration;
                    return _currRet;
                }
                else
                    return DateTime.Now - _startTime;
            }
            else if (State == StopWatchState.Paused)
            {
                if (_currRet > TimeSpan.Zero)
                    return _currRet;
                else
                    return _pausedStartTime - _startTime;
            }
            else
                return new TimeSpan(0, 0, 0, 0, 0);

        }

        public void Start()
        {
            if (State == StopWatchState.Paused)
            {
                _state = StopWatchState.Running;
                _pausedEnd = DateTime.Now;
                _pausedDuration = _pausedEnd - _pausedStartTime;
                _lstPausedDuration.Add(_pausedDuration);
            }
            else
                _startTime = DateTime.Now;
        }

        public StopWatchItems Stop()
        {
            var _endTime = DateTime.Now;
            var ret = new StopWatchItems
            {
                RoundTime = _endTime - _startTime,
                TimeStamp = DateTime.Now

            };

            _state = StopWatchState.Idle;
            _reset = true;
            if (ret.RoundTime > TimeSpan.Zero)
                return ret;
            else
                return null;
        }

        public void Pause()
        {

            _pausedStartTime = DateTime.Now;
            _state = StopWatchState.Paused;


        }
    }
}
