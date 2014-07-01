using System;
using System.Collections.Generic;
using Sandwich.Core.Interface;

namespace Sandwich.Core.ValueConverters
{
    public class LongConverter : IValueConverter
    {
        public object Convert(string value)
        {
            return long.Parse(value);
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