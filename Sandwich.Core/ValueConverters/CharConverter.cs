using System;
using System.Globalization;

namespace Sandwich.Core.ValueConverters
{
    public class CharConverter : NullableTypeConverterBase<char, char?>
    {
        public CharConverter(IFormatProvider formatProvider)
            : base(formatProvider)
        {
        }

        protected override object InternalConvert(string value)
        {
            if (value.Length == 1)
                return char.Parse(value);

            var num = int.Parse(value, NumberStyles.AllowHexSpecifier);
            var cnum = (char)num;
            return cnum;
        }
    }
}