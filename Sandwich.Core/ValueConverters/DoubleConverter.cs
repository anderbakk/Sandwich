using System;

namespace Sandwich.Core.ValueConverters
{
    public class DoubleConverter : NullableTypeConverterBase<double, double?>
    {
        public DoubleConverter(IFormatProvider formatProvider)
            : base(formatProvider)
        {
        }

        protected override object InternalConvert(string value)
        {
            return double.Parse(value, FormatProvider);
        }
    }
}