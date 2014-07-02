using System;
using System.Globalization;
using Sandwich.Core.Exceptions;
using Sandwich.Core.Interface;

namespace Sandwich.Core.ValueConverters
{

    public class ValueConverterFacade : IConvertValues
    {
        private readonly ConverterFactory _factory;

        public ValueConverterFacade(ConverterFactory factory)
        {
            _factory = factory;
        }

        public object ConvertValue(string value, Type type)
        {
            return Convert(value, type);
        }

        private object Convert(string value, Type type)
        {
            var converter = _factory.GetConverter(type);

            if (converter == null)
                throw new ValueConversionNotSupportedException(string.Format("Could not find a converter for type {0}",
                    type));

            return converter.Convert(value);
        }

        public T ConvertValue<T>(string value)
        {
            return (T) Convert(value, typeof (T));
        }
    }
}