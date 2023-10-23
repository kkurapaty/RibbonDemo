using System;
using System.Windows.Markup;

namespace RibbonDemo.Controls
{
    [MarkupExtensionReturnType(typeof(VectorIcon))]
    public class VectorIconExtension : MarkupExtension
    {
        public VectorIconExtension()
        { }

        public VectorIconExtension(VectorIconKind kind)
        {
            Kind = kind;
        }

        public VectorIconExtension(VectorIconKind kind, double size)
        {
            Kind = kind;
            Size = size;
        }

        [ConstructorArgument("kind")]
        public VectorIconKind Kind { get; set; }

        [ConstructorArgument("size")]
        public double? Size { get; set; }

        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            var result = new VectorIcon { Kind = Kind };

            if (Size.HasValue)
            {
                result.Height = Size.Value;
                result.Width = Size.Value;
            }

            return result;
        }
    }
}