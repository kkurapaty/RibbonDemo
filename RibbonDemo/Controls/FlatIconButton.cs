using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace RibbonDemo.Controls
{
    public class FlatIconButton : Button
    {
        #region - Constructor -
        public FlatIconButton()
        {
            DefaultStyleKey = typeof(FlatIconButton);
        } 
        #endregion

        #region - IconData Property -
        public static readonly DependencyProperty IconDataProperty = DependencyProperty.Register("IconData", typeof(Geometry), typeof(FlatIconButton));

        public Geometry IconData
        {
            get => (Geometry)GetValue(IconDataProperty);
            set => SetValue(IconDataProperty, value);
        }
        #endregion

        #region - FillColor Property -
        public static readonly DependencyProperty FillColorProperty = DependencyProperty.Register("FillColor", typeof(Brush), typeof(FlatIconButton), new FrameworkPropertyMetadata(defaultValue: Brushes.Black));

        public Brush FillColor
        {
            get => (Brush)GetValue(FillColorProperty);
            set => SetValue(FillColorProperty, value);
        } 
        #endregion

        #region - OutlineColor Property -
        public static readonly DependencyProperty OutlineColorProperty = DependencyProperty.Register("OutlineColor", typeof(Brush), typeof(FlatIconButton), new FrameworkPropertyMetadata(defaultValue: Brushes.DarkGray));

        public Brush OutlineColor
        {
            get => (Brush)GetValue(OutlineColorProperty);
            set => SetValue(OutlineColorProperty, value);
        } 
        #endregion

        #region - HighlightColor Property -
        public static readonly DependencyProperty HighlightColorProperty = DependencyProperty.Register("HighlightColor", typeof(Brush), typeof(FlatIconButton), new FrameworkPropertyMetadata(defaultValue: Brushes.WhiteSmoke));

        public Brush HighlightColor
        {
            get => (Brush)GetValue(HighlightColorProperty);
            set => SetValue(HighlightColorProperty, value);
        }

        #endregion

        #region - IconHeight Property -
        public static readonly DependencyProperty IconHeightProperty = DependencyProperty.Register("IconHeight", typeof(double), typeof(FlatIconButton), new FrameworkPropertyMetadata((double)20));

        public double IconHeight
        {
            get => (double)GetValue(IconHeightProperty);
            set => SetValue(IconHeightProperty, value);
        }
        #endregion

        #region - IconWidth Property -
        public static readonly DependencyProperty IconWidthProperty = DependencyProperty.Register("IconWidth", typeof(double), typeof(FlatIconButton), new FrameworkPropertyMetadata((double)20));

        public double IconWidth
        {
            get => (double)GetValue(IconWidthProperty);
            set => SetValue(IconWidthProperty, value);
        } 
        #endregion

        #region - Scale Property -
        public static readonly DependencyProperty ScaleProperty = DependencyProperty.Register(
    nameof(Scale), typeof(int), typeof(FlatIconButton), new PropertyMetadata(1));

        public int Scale
        {
            get => (int)GetValue(ScaleProperty);
            set => SetValue(ScaleProperty, value);
        } 
        #endregion

        #region - Angle Property -
        public static readonly DependencyProperty AngleProperty = DependencyProperty.Register(
    nameof(Angle), typeof(double), typeof(FlatIconButton), new PropertyMetadata(default(double)));

        public double Angle
        {
            get => (double)GetValue(AngleProperty);
            set => SetValue(AngleProperty, value);
        } 
        #endregion
    }
}
