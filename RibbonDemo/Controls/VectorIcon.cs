using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace RibbonDemo.Controls
{
    public class VectorIcon : Control
    {
        private static readonly Lazy<IDictionary<VectorIconKind, string>> _dataIndex = new Lazy<IDictionary<VectorIconKind, string>>(VectorIconDataFactory.Create);

        static VectorIcon()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(VectorIcon), new FrameworkPropertyMetadata(typeof(VectorIcon)));
        }

        public static readonly DependencyProperty KindProperty
            = DependencyProperty.Register(nameof(Kind), typeof(VectorIconKind), typeof(VectorIcon), new PropertyMetadata(default(VectorIconKind), KindPropertyChangedCallback));

        private static void KindPropertyChangedCallback(DependencyObject dependencyObject, DependencyPropertyChangedEventArgs dependencyPropertyChangedEventArgs) => ((VectorIcon)dependencyObject).UpdateData();

        /// <summary>
        /// Gets or sets the icon to display.
        /// </summary>
        public VectorIconKind Kind
        {
            get => (VectorIconKind)GetValue(KindProperty);
            set => SetValue(KindProperty, value);
        }

        private static readonly DependencyPropertyKey DataPropertyKey
            = DependencyProperty.RegisterReadOnly(nameof(Data), typeof(string), typeof(VectorIcon), new PropertyMetadata(""));

        // ReSharper disable once StaticMemberInGenericType
        public static readonly DependencyProperty DataProperty = DataPropertyKey.DependencyProperty;

        /// <summary>
        /// Gets the icon path data for the current <see cref="Kind"/>.
        /// </summary>
        [TypeConverter(typeof(GeometryConverter))]
        public string Data
        {
            get => (string)GetValue(DataProperty);
            private set => SetValue(DataPropertyKey, value);
        }

        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();
            UpdateData();
        }

        private void UpdateData()
        {
            string data = null;
            _dataIndex.Value?.TryGetValue(Kind, out data);
            Data = data;
        }
        #region - Scale Property -
        public static readonly DependencyProperty ScaleProperty = DependencyProperty.Register(
            nameof(Scale), typeof(int), typeof(VectorIcon), new PropertyMetadata(1));

        public int Scale
        {
            get => (int)GetValue(ScaleProperty);
            set => SetValue(ScaleProperty, value);
        }
        #endregion

        #region - Angle Property -
        public static readonly DependencyProperty AngleProperty = DependencyProperty.Register(
            nameof(Angle), typeof(double), typeof(VectorIcon), new PropertyMetadata(0.0));

        public double Angle
        {
            get => (double)GetValue(AngleProperty);
            set => SetValue(AngleProperty, value);
        }
        #endregion
    }
}