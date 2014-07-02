using System;
using System.Collections.Generic;
using System.Globalization;
using Sandwich.Core.Interface;

namespace Sandwich.Core.ValueConverters
{
    public class LongConverter : IValueConverter
    {
        private readonly IFormatProvider _formatProvider;

        public LongConverter(IFormatProvider formatProvider)
        {
            _formatProvider = formatProvider;
        }

        public object Convert(string value)
        {
            return long.Parse(value, _formatProvider);
        }

        public IEnumerable<Type> SupportedTypes
        {
            get
            {
                return new List<Type>
                {
                    typeof (long?),
                    typeof(long)
                };
            }
        }
    }

    public class NullableLongConverter : IValueConverter
    {
        private readonly IFormatProvider _formatProvider;

        public NullableLongConverter(IFormatProvider formatProvider)
        {
            _formatProvider = formatProvider;
        }

        public object Convert(string value)
        {
            long i;
            if (long.TryParse(value, NumberStyles.None,_formatProvider, out i)) return i;
            return null;
        }

        public IEnumerable<Type> SupportedTypes
        {
            get
            {
                return new List<Type>
                {
                    typeof (long?)
                };
            }
        }
    }
}