using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StopWatch.ViewModels
{
    public class StopWatchViewModel :INotifyPropertyChanged
    {
        public StopWatchCore.Models.StopWatch _watch = new StopWatchCore.Models.StopWatch();

        protected virtual void OnPropertyChanged(String propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }


        private TimeSpan _currentTime;
        public TimeSpan CurrentTime
        {
            get
            {
                return _watch.GetCurrentTime();
            }
            set
            {
                if (_currentTime == value)
                    return;

                _currentTime = value;
                OnPropertyChanged("CurrentTime");
            }
        }

     

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
