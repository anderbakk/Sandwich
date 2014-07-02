using System;

namespace Sandwich.Core.ValueConverters
{
    public class LongConverter : NullableTypeConverterBase<long, long?>
    {
        public LongConverter(IFormatProvider formatProvider) : base(formatProvider)
        {
        }

        protected override object InternalConvert(string value)
        {
            return long.Parse(value, FormatProvider);
        }
    }
}