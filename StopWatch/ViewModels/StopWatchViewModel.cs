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

        public StopWatchViewModel()
        {
            var saveList = SaveWatch.LoadSaveGames();
            if (saveList == null)
                return;
            if (saveList.Count == 1)
                _lstRoundTimes.Add(saveList.FirstOrDefault());
            else if (saveList.Count > 1)
            {
                foreach (var item in saveList)
                    _lstRoundTimes.Add(item);
            }
            else
                return;

        }

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

        
        public ObservableCollection<StopWatchItems> LstRoundTimes
        {
            get
            {
                return _lstRoundTimes;
            }
            set
            {

                if (_lstRoundTimes == value || _lstRoundTimes.Count == 0)
                    return;

                _lstRoundTimes = value;
                OnPropertyChanged(nameof(LstRoundTimes));
                OnPropertyChanged(nameof(Id));
            }
        }


        public DateTime TimeStamp
        {
            get
            {
                return _watchItem.TimeStamp;
            }
        }

        public int Id
        {
            get
            {
                var index= LstRoundTimes.IndexOf(SelectedStopItem);
                return index;

            }
        }

        private StopWatchItems _selectedStopItem;
        public StopWatchItems SelectedStopItem
        {
            get
            {
                return _selectedStopItem;
            }
            set
            {

                if (_selectedStopItem == value)
                    return;

                _selectedStopItem = value;
                OnPropertyChanged(nameof(SelectedStopItem));
                OnPropertyChanged(nameof(IsSaved));
                OnPropertyChanged(nameof(Id));
                OnPropertyChanged(nameof(LstRoundTimes));
            }
        }
        private int _selectedStopItemIndex;
        public int SelectedStopItemIndex
        {
            get
            {
                return _selectedStopItemIndex;
            }
            set
            {

                if (_selectedStopItemIndex == value)
                    return;

                _selectedStopItemIndex = value;
                OnPropertyChanged(nameof(SelectedStopItemIndex));
            }
        }
        private bool _isSaved;
        public bool IsSaved
        {
            get
            {
                if (SaveWatch.IsSaved(SelectedStopItem))
                    return true;
                else
                    return _isSaved;

            }
            set
            {
                if (_isSaved == value)
                    return;

                _isSaved = value;
                OnPropertyChanged(nameof(IsSaved));
            }
        }

        internal void Save(StopWatchItems save)
        {
            SaveWatch.Save(save);
            LstRoundTimes.Add(save);
            //OnPropertyChanged(nameof(LstRoundTimes));
            OnPropertyChanged(nameof(IsSaved));
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

        internal void Delete(StopWatchItems delete)
        {
            SaveWatch.Delete(delete);
            LstRoundTimes.Remove(delete);
        }

    }
}
