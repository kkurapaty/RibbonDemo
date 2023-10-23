using System;
using System.Windows.Controls;
using System.Windows.Input;

namespace RibbonDemo
{
    public class ConfigItem: BaseViewModel
    {
        private string _configName;
        private string _configDisplayName;
        private bool _isSelected;
        private ConfigItemType _configItemType;

        public ConfigItem()
        {
            
        }
        public ConfigItem(ConfigItemType configType, string name, string displayName, Action<ConfigItem> callback = null):this()
        {
            ConfigGroup = configType;
            ConfigName = name;
            ConfigDisplayName = displayName;
            ConfigCallback = callback;
        }

        public ConfigItemType ConfigGroup { get => _configItemType; set => SetProperty(ref _configItemType, value); }
        public string ConfigName { get => _configName; set => SetProperty(ref _configName, value); }
        public string ConfigDisplayName { get => _configDisplayName; set => SetProperty(ref _configDisplayName, value); }
        public bool IsSelected
        {
            get => _isSelected;
            set
            {
                SetProperty(ref _isSelected, value);
                DoOnSelection();
            }
        }
        public override string ToString()
        {
            return ConfigDisplayName;
        }

        public Action<ConfigItem> ConfigCallback {get; set; }

        public bool SuspendUpdateEvent {get; set; }

        private void DoOnSelection()
        {
            if (ConfigCallback != null && !SuspendUpdateEvent)
            {
                ConfigCallback(this);
            }
        }
    }

    public enum ConfigItemType
    {
        TimePeriod,
        RecordType,
        SelectAYear
    }
}