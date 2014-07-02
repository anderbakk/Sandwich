using System;

namespace Sandwich.Core.ValueConverters
{
    public class ValueConverterFacade
    {
        private readonly ConverterFactory _factory;

        public ValueConverterFacade(ConverterFactory factory)
        {
            _factory = factory;
        }

        public object ConvertValue(string value, Type type)
        {
            var converter = _factory.GetConverter(type);

            return converter == null ? Activator.CreateInstance(type) : converter.Convert(value);
        }

        public T ConvertValue<T>(string value)
        {
            var converter = _factory.GetConverter(typeof(T));

            if (converter == null)
                return default (T);
            return (T) converter.Convert(value);
        }
    }
}