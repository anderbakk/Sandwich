using System;

namespace Sandwich.Core.ValueConverters
{
    public class ByteConverter : NullableTypeConverterBase<byte, byte?>
    {
        public ByteConverter(IFormatProvider formatProvider)
            : base(formatProvider)
        {
        }

        protected override object InternalConvert(string value)
        {
            return byte.Parse(value, FormatProvider);
        }
    }
}