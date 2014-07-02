using System;

namespace Sandwich.Core.ValueConverters
{
    public class IntConverter : NullableTypeConverterBase<int, int?>
    {
        public IntConverter(IFormatProvider formatProvider) : base(formatProvider)
        {
        }

        protected override object InternalConvert(string value)
        {
            return int.Parse(value, FormatProvider);
        }
    }
}