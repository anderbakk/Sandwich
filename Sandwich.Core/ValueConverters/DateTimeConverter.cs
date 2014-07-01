using System;
using System.Collections.Generic;
using Sandwich.Core.Interface;

namespace Sandwich.Core.ValueConverters
{
    public class DateTimeConverter : IValueConverter
    {
        private readonly IFormatProvider _formatProvider;

        public DateTimeConverter(IFormatProvider formatProvider)
        {
            _formatProvider = formatProvider;
        }

        public object Convert(string value)
        {
            return DateTime.Parse(value, _formatProvider);
        }

        public IEnumerable<Type> SupportedTypes
        {
            get
            {
                return new List<Type>
                {
                    typeof (DateTime)
                };
            }
        }
    }
}