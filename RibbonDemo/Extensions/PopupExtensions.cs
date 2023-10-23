using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;

namespace RibbonDemo.Extensions
{
    public static class PopupExtensions
    {
        private static bool _canAutoClose = true;
        public static readonly DependencyProperty AutoHideOnLinkClickProperty = DependencyProperty.RegisterAttached(
            "AutoHideOnLinkClick", typeof(bool), typeof(PopupExtensions), new PropertyMetadata(default(bool), OnAutoHideOnLinkClickPropertyChanged));

        private static void OnAutoHideOnLinkClickPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if ((bool)e.NewValue)
            {
                if (d is Popup popup)
                    popup.InitializeAutoHideOnLinkClick();
            }
        }

        public static void SetAutoHideOnLinkClick(DependencyObject element, bool value)
        {
            element.SetValue(AutoHideOnLinkClickProperty, value);
            if (value)
            {
                if (element is Popup popup)
                    popup.InitializeAutoHideOnLinkClick();
            }
        }

        public static bool GetAutoHideOnLinkClick(DependencyObject element)
        {
            return (bool)element.GetValue(AutoHideOnLinkClickProperty);
        }

        private static void InitializeAutoHideOnLinkClick(this Popup popup)
        {
            var onButtonClick = new RoutedEventHandler((s, e) =>
            {
                if (!(s is CheckBox) && !(s is RepeatButton) && !(s is ComboBox) &&
                    !(s is ToggleButton toggleButton && toggleButton.Name == "toggleButton")) popup.IsOpen = !_canAutoClose;
            });

            var onSelectionChanged = new SelectionChangedEventHandler((s, e) => { popup.IsOpen = !_canAutoClose; });

            var onPopupChildLoaded = new RoutedEventHandler((s, e) =>
            {
                foreach (var button in popup.Child.Descendents().OfType<ButtonBase>())
                {
                    button.Click -= onButtonClick;
                    button.Click += onButtonClick;
                }

                foreach (var control in popup.Child.Descendents().OfType<ComboBox>())
                {
                    control.SelectionChanged -= onSelectionChanged;
                    control.SelectionChanged += onSelectionChanged;
                }
            });

            var onPopupChildUnLoaded = new RoutedEventHandler((s, e) =>
            {
                foreach (var button in popup.Child.Descendents().OfType<ButtonBase>())
                {
                    button.Click -= onButtonClick;
                }
            });

            popup.Opened += (s, e) =>
            {
                var child = popup.Child as FrameworkElement;
                if (child == null) return;
                child.Loaded -= onPopupChildLoaded;
                child.Loaded += onPopupChildLoaded;

                child.Unloaded -= onPopupChildUnLoaded;
                child.Unloaded += onPopupChildUnLoaded;
            };

            popup.Loaded += (s, e) =>
            {
                var child = popup.Child as FrameworkElement;
                if (child == null) return;
                child.Loaded -= onPopupChildLoaded;
                child.Loaded += onPopupChildLoaded;

                child.Unloaded -= onPopupChildUnLoaded;
                child.Unloaded += onPopupChildUnLoaded;
            };
        }

        public static readonly DependencyProperty CanAutoCloseProperty = DependencyProperty.RegisterAttached(
            "CanAutoClose", typeof(bool), typeof(PopupExtensions), new PropertyMetadata(default(bool), OnCanAutoClosePropertyChanged));

        private static void OnCanAutoClosePropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (e.NewValue != e.OldValue)
                _canAutoClose = (bool)e.NewValue;
        }

        public static void SetCanAutoClose(DependencyObject element, bool value)
        {
            element.SetValue(CanAutoCloseProperty, value);
            _canAutoClose = value;
        }

        public static bool GetCanAutoClose(DependencyObject element)
        {
            return (bool)element.GetValue(CanAutoCloseProperty);
        }
    }
}
