using System;

namespace Sandwich.Core.ValueConverters
{
    public class DateTimeConverter : NullableTypeConverterBase<DateTime, DateTime?>
    {
        public DateTimeConverter(IFormatProvider formatProvider) : base(formatProvider)
        {
        }

        protected override object InternalConvert(string value)
        {
            return DateTime.Parse(value, FormatProvider);
        }
    }
}