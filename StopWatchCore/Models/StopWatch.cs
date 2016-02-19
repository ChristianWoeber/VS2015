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
        private TimeSpan _currTime;
        private List<TimeSpan> _lstPausedDuration = new List<TimeSpan>();
        private DateTime _pausedEnd;



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
                _currTime = DateTime.Now - _startTime - _pausedDuration;
                return _currTime;
            }
            else if (State == StopWatchState.Paused)
            {
                return _currTime;
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
            }
            else
                _startTime = DateTime.Now;
        }
       
        private int _count=0;
        public StopWatchItems Stop()
        {
            if (_currTime > TimeSpan.Zero)
            {
                _count++;       
                    
                var _endTime = _currTime;
                var ret = new StopWatchItems
                {
                    RoundTime = _endTime,
                    TimeStamp = DateTime.Now,
                    //Id = 0

                };

                _state = StopWatchState.Idle;
                if (ret.RoundTime > TimeSpan.Zero)
                {
                    _currTime = TimeSpan.Zero;
                    return ret;
                }
            }
                return null;
        }

        public void Pause()
        {
            _pausedStartTime = DateTime.Now;
            _state = StopWatchState.Paused;
        }
    }
}
