using System;

namespace Sandwich.Core.ValueConverters
{
    public class BoolConverter : NullableTypeConverterBase<bool, bool?>
    {
        public BoolConverter(IFormatProvider formatProvider)
            : base(formatProvider)
        {
        }

        protected override object InternalConvert(string value)
        {
            return bool.Parse(value);
        }
    }
}