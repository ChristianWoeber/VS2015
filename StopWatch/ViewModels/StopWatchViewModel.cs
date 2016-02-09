using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StopWatchCore.Models;

namespace StopWatch.ViewModels
{
    public class StopWatchViewModel : INotifyPropertyChanged
    {
        private ObservableCollection<StopWatchItems> _lstRoundTimes = new ObservableCollection<StopWatchItems>();
        private StopWatchCore.Models.StopWatch _watch = new StopWatchCore.Models.StopWatch();
        private StopWatchItems _watchItem = new StopWatchItems();

        protected virtual void OnPropertyChanged(String propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

        public event PropertyChangedEventHandler PropertyChanged;

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

        public ObservableCollection<StopWatchItems> LstRoundTimes => _lstRoundTimes;


        public DateTime TimeStamp
        {
            get
            {
                return _watchItem.TimeStamp;
            }
        }
        private int _id;
        public int Id
        {
            get
            {
                return _id;
            }
            set
            {

                if (_watchItem.Id == value)
                    return;

                _watchItem.Id = _id = value;
                OnPropertyChanged(nameof(Id));
            }
        }


        internal void Start()
        {
            _watch.Start();
        }

        internal void Pause()
        {
            _watch.Pause();
        }

        internal StopWatchItems Stop()
        {
            var ret = _watch.Stop();
            if (ret != null && ret.TimeStamp != DateTime.MinValue)
            {
                _lstRoundTimes.Add(ret);

            }
            return ret;
        }
    }
}
