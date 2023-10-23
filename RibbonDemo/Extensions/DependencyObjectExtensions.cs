using System.Collections.Generic;
using System.Windows;
using System.Windows.Media;

namespace RibbonDemo.Extensions
{
    public static class DependencyObjectExtensions
    {
        public static IEnumerable<DependencyObject> Descendents(this DependencyObject element)
        {
            int count = VisualTreeHelper.GetChildrenCount(element);
            for (int i = 0; i < count; i++)
            {
                var child = VisualTreeHelper.GetChild(element, i);
                yield return child;
                foreach(var d in Descendents(child))
                    yield return d;
            }
        }
    }
}