using System;
using System.Collections.Generic;
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
}