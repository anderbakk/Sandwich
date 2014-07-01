using System;
using System.Collections.Generic;
using System.Linq;
using Sandwich.Core.Interface;

namespace Sandwich.Core.ValueConverters
{
    public class ConverterFactory
    {
        private readonly IEnumerable<IValueConverter> _converters;

        public ConverterFactory(IEnumerable<IValueConverter> converters)
        {
            _converters = converters;
        }

        public IValueConverter GetConverter(Type type)
        {
            var converter = _converters.FirstOrDefault(c => c.SupportedTypes.Contains(type));

            return converter;
        }
    }
}