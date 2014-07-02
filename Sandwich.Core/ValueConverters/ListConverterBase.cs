using System;
using System.Collections.Generic;
using Sandwich.Core.Interface;

namespace Sandwich.Core.ValueConverters
{
    public abstract class ListConverterBase<T> : IValueConverter
    {
        private readonly char _separator;

        protected ListConverterBase(char separator)
        {
            _separator = separator;
        }

        public object Convert(string value)
        {
            var values = value.Split(_separator);
            return InternalConvert(values);
        }

        protected abstract T InternalConvert(string[] values);

        public IEnumerable<Type> SupportedTypes
        {

            get { return typeof (T).GetInterfaces(); }
        }
    }
}