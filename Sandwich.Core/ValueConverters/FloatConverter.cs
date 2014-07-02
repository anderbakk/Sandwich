using System;

namespace Sandwich.Core.ValueConverters
{
    public class FloatConverter : NullableTypeConverterBase<float, float?>
    {
        public FloatConverter(IFormatProvider formatProvider)
            : base(formatProvider)
        {
        }

        protected override object InternalConvert(string value)
        {
            return float.Parse(value, FormatProvider);
        }
    }
}