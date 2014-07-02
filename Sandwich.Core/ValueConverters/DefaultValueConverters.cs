using System;
using System.Collections.Generic;
using System.Globalization;
using Sandwich.Core.Interface;

namespace Sandwich.Core.ValueConverters
{
    public static class DefaultValueConverters
    {
        public static IConvertValues CreateDefaultValueConverter(CultureInfo cultureInfo)
        {
            return new ValueConverterFacade(new ConverterFactory(GetAll(cultureInfo)));
        }

        public static IEnumerable<IValueConverter> GetAll(CultureInfo cultureInfo)
        {
            return GetSpecific(cultureInfo,
                true, true, true, true, true, true, true, true, true, true, true);
        }

        public static IEnumerable<IValueConverter> GetSpecific(CultureInfo cultureInfo,
            bool boolConverter = false,
            bool floatConverter = false,
            bool byteConverter = false,
            bool decimalConverter = false,
            bool doubleConverter = false,
            bool dateTimeConverter = false,
            bool charConverter = false,
            bool stringConverter = false,
            bool longConverter = false,
            bool intConverter = false,
            bool stringArrayConverter = false)
        {

            var converters = new List<IValueConverter>();

            Add(stringConverter, () => new StringConverter(), converters);
            Add(longConverter, () => new LongConverter(cultureInfo.NumberFormat), converters);
            Add(intConverter, () => new IntConverter(cultureInfo.NumberFormat), converters);
            Add(charConverter, () => new CharConverter(cultureInfo.NumberFormat), converters);
            Add(boolConverter, () => new BoolConverter(cultureInfo.NumberFormat), converters);
            Add(floatConverter, () => new FloatConverter(cultureInfo.NumberFormat), converters);
            Add(byteConverter, () => new ByteConverter(cultureInfo.NumberFormat), converters);
            Add(decimalConverter, () => new DecimalConverter(cultureInfo.NumberFormat), converters);
            Add(doubleConverter, () => new DoubleConverter(cultureInfo.NumberFormat), converters);
            Add(dateTimeConverter, () => new DateTimeConverter(cultureInfo.NumberFormat), converters);
            Add(stringArrayConverter, () => new StringArrayConverter(','), converters);

            return converters;
        }

        private static void Add(bool useConverter, Func<IValueConverter> func, List<IValueConverter> converters)
        {
            if (useConverter)
                converters.Add(func.Invoke());
        }
    }
}