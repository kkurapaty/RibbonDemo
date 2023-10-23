using System;
using System.Windows;
using System.Windows.Controls.Primitives;

namespace RibbonDemo.Controls
{
    public class FilterButton: ToggleButton
    {
        public static readonly DependencyProperty DropdownContentProperty = DependencyProperty.Register(
            nameof(DropdownContent), typeof(FrameworkElement), typeof(FilterButton), new PropertyMetadata(null));

        public FrameworkElement DropdownContent
        {
            get => (FrameworkElement)GetValue(DropdownContentProperty);
            set => SetValue(DropdownContentProperty, value);
        }

        public static readonly DependencyProperty LeftIconProperty = DependencyProperty.Register(
            nameof(LeftIcon), typeof(VectorIconKind), typeof(FilterButton), new PropertyMetadata(VectorIconKind.Filter));

        public VectorIconKind LeftIcon
        {
            get => (VectorIconKind)GetValue(LeftIconProperty);
            set => SetValue(LeftIconProperty, value);
        }

        public static readonly DependencyProperty RightIconProperty = DependencyProperty.Register(
            nameof(RightIcon), typeof(VectorIconKind), typeof(FilterButton), new PropertyMetadata(VectorIconKind.ChevronDown));

        public VectorIconKind RightIcon
        {
            get => (VectorIconKind)GetValue(RightIconProperty);
            set => SetValue(RightIconProperty, value);
        }

        public static readonly DependencyProperty IsOpenProperty = DependencyProperty.Register(
            nameof(IsOpen), typeof(bool), typeof(FilterButton), new PropertyMetadata(default(bool)));

        public bool IsOpen
        {
            get { return (bool)GetValue(IsOpenProperty); }
            set { SetValue(IsOpenProperty, value); }
        }

        public static readonly DependencyProperty HeaderTextProperty = DependencyProperty.Register(
            nameof(HeaderText), typeof(string), typeof(FilterButton), new PropertyMetadata(default(string)));

        public string HeaderText
        {
            get { return (string)GetValue(HeaderTextProperty); }
            set { SetValue(HeaderTextProperty, value); }
        }
    }
}
