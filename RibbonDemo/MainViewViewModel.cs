using System;
using System.Collections.ObjectModel;
using System.Linq;
using RibbonDemo.Extensions;

namespace RibbonDemo
{
    public class MainViewViewModel : BaseViewModel
    {
        private ObservableCollection<ConfigItem> _timePeriods = new ObservableCollection<ConfigItem>();
        private ObservableCollection<ConfigItem> _recordTypes = new ObservableCollection<ConfigItem>();
        private ObservableCollection<ConfigItem> _selectableYears = new ObservableCollection<ConfigItem>();
        private ConfigItem _selectedTimePeriod;
        private ConfigItem _selectedRecordType;
        private ConfigItem _selectedYear;
        

        public MainViewViewModel()
        {
            PopulateData();
        }

        public string HeaderText
        {
            get
            {
                if (IsYearSelected) return $"Year {SelectedYear.ConfigName}";
                return TimePeriods.FirstOrDefault(x => x.IsSelected)?.ConfigDisplayName ?? "Filter By";
            }
        }

        public ObservableCollection<ConfigItem> TimePeriods
        {
            get => _timePeriods;
            set => SetProperty(ref _timePeriods, value);
        }

        public ObservableCollection<ConfigItem> RecordTypes
        {
            get => _recordTypes;
            set => SetProperty(ref _recordTypes, value);
        }
        public ObservableCollection<ConfigItem> SelectableYears
        {
            get => _selectableYears;
            set => SetProperty(ref _selectableYears, value);
        }
        public ConfigItem SelectedTimePeriod
        {
            get => _selectedTimePeriod;
            set
            {
                SetProperty(ref _selectedTimePeriod, value);
                OnPropertyChanged(nameof(HeaderText));
            }
        }

        public ConfigItem SelectedRecordType
        {
            get => _selectedRecordType; set
            {
                SetProperty(ref _selectedRecordType, value);
                OnPropertyChanged(nameof(HeaderText));
            }
        }


        public ConfigItem SelectedYear
        {
            get => _selectedYear; 
            set 
            { 
                SetProperty(ref _selectedYear, value); 
                OnPropertyChanged(nameof(HeaderText));
            }
        }

        public bool IsYearSelected => (SelectedYear != null && TimePeriods.FirstOrDefault(x=> x.IsSelected && x.ConfigName == TimePeriod.SelectAYear.ToString()) != null);

        public bool CanCloseFilterPopup
        {
            get
            {
                if (TimePeriods.FirstOrDefault(x => x.IsSelected)?.ConfigName == TimePeriod.SelectAYear.ToString())
                    return (SelectedYear != null);
                return true;
            }
        }
        

        private void PopulateData()
        {
            foreach (var t in Enum.GetValues(typeof(TimePeriod)).Cast<TimePeriod>())
            {
                TimePeriods.Add(new ConfigItem(ConfigItemType.TimePeriod, t.ToString(), t.GetDescription(), OnSelectionChanged));
            }

            foreach (var t in Enum.GetValues(typeof(RecordType)).Cast<RecordType>())
            {
                RecordTypes.Add(new ConfigItem(ConfigItemType.RecordType, t.ToString(), t.GetDescription(), OnSelectionChanged));
            }

            foreach (var t in Enumerable.Range(DateTime.Today.Year-10, 8))
            {
                SelectableYears.Add(new ConfigItem(ConfigItemType.SelectAYear, $"{t}", $"{t}", OnSelectionChanged));
            }
        }

        private void OnSelectionChanged(ConfigItem configItem)
        {
            ResetTimePeriods(configItem);
            ResetRecordTypes(configItem);
            ResetYearSelection(configItem);
        }

        private void ResetTimePeriods(ConfigItem configItem)
        {
            if (configItem.IsSelected && configItem.ConfigGroup == ConfigItemType.TimePeriod)
            {
                foreach (var item in TimePeriods.Where(x => x.ConfigName != configItem.ConfigName))
                {
                    item.SuspendUpdateEvent = true;
                    item.IsSelected = false;
                    item.SuspendUpdateEvent = false;
                }
            }
            OnPropertyChanged(nameof(HeaderText));
            OnPropertyChanged(nameof(CanCloseFilterPopup));
        }

        private void ResetRecordTypes(ConfigItem configItem)
        {
            if (configItem.IsSelected && configItem.ConfigGroup == ConfigItemType.RecordType)
            {
                foreach (var item in RecordTypes.Where(x => x.ConfigName != configItem.ConfigName))
                {
                    item.SuspendUpdateEvent = true;
                    item.IsSelected = false;
                    item.SuspendUpdateEvent = false;
                }
            }
            OnPropertyChanged(nameof(HeaderText));
        }

        private void ResetYearSelection(ConfigItem configItem)
        {
            if (configItem.IsSelected && configItem.ConfigGroup == ConfigItemType.SelectAYear)
            {
                foreach (var item in SelectableYears.Where(x => x.ConfigName != configItem.ConfigName))
                {
                    item.SuspendUpdateEvent = true;
                    item.IsSelected = false;
                    item.SuspendUpdateEvent = false;
                }
            }
            OnPropertyChanged(nameof(HeaderText));
        }

    }
}