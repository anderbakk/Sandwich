using System;
using System.Collections.Generic;
using Sandwich.Core.Interface;

namespace Sandwich.Core.ValueConverters
{
    public abstract class NullableTypeConverterBase<T, TNullable> : IValueConverter
    {
        protected readonly IFormatProvider FormatProvider;

        protected NullableTypeConverterBase(IFormatProvider formatProvider)
        {
            FormatProvider = formatProvider;
        }

        public object Convert(string value)
        {
            return InternalConvert(value);
        }

        protected abstract object InternalConvert(string value);

        public IEnumerable<Type> SupportedTypes
        {
            get { return new List<Type> { typeof(T), typeof(TNullable) }; }
        }
    }
}