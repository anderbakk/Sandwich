using System;
using System.Collections.Generic;
using Sandwich.Core.Interface;

namespace Sandwich.Core.ValueConverters
{
    public class StringConverter : IValueConverter
    {
        public object Convert(string value)
        {
            return value;
        }

        public IEnumerable<Type> SupportedTypes { get { return new List<Type> {typeof (string)}; }}
    }
}