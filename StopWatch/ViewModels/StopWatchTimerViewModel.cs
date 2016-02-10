using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StopWatchCore.Models;

namespace StopWatch.ViewModels
{
    public class StopWatchTimerViewModel : INotifyPropertyChanged
    {
        public StopWatchTimer _watch = new StopWatchTimer();

        public event PropertyChangedEventHandler PropertyChanged;


        protected virtual void OnPropertyChanged(String propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

        public TimeSpan CurrentTimeTimer
        {
            get
            {                             
                return _watch.GetCurrentTime();
            }

        }
        private int _currentTimeMilliseconds;
        public int CurrentTimeMilliseconds
        {
            get
            {                
                return _currentTimeMilliseconds;
            }
            set
            {
                if (_watch.GetCurrentTime().Milliseconds == value)
                    return;

                _currentTimeMilliseconds = value;
                OnPropertyChanged(nameof(CurrentTimeMilliseconds));
            }
        }
        public string CurrentTimeSeconds
        {
            get
            {
                return _watch.GetCurrentTime().Seconds.ToString();
            }

        }
        public string CurrentTimeMinutes
        {
            get
            {
               return _watch.GetCurrentTime().Minutes.ToString();
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
