namespace Sandwich.Core.ValueConverters
{
    public class ValueConverter
    {
        private readonly ConverterFactory _factory;

        public ValueConverter(ConverterFactory factory)
        {
            _factory = factory;
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