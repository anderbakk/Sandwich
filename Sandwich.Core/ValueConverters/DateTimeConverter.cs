using System;
using System.Collections.Generic;
using Sandwich.Core.Interface;

namespace Sandwich.Core.ValueConverters
{
    public class DateTimeConverter : IValueConverter
    {
        public object Convert(string value)
        {
            return DateTime.Parse(value);
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