using System;

namespace Sandwich.Core.ValueConverters
{
    public class DecimalConverter : NullableTypeConverterBase<decimal, decimal?>
    {
        public DecimalConverter(IFormatProvider formatProvider)
            : base(formatProvider)
        {
        }

        protected override object InternalConvert(string value)
        {
            return decimal.Parse(value, FormatProvider);
        }
    }
}