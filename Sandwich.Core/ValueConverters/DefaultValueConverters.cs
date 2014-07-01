using System.Collections.Generic;
using System.Globalization;
using System.Threading;
using Sandwich.Core.Interface;

namespace Sandwich.Core.ValueConverters
{
    public static class DefaultValueConverters
    {
        public static IEnumerable<IValueConverter> Get()
        {
            var cultureInfo = Thread.CurrentThread.CurrentCulture;
            return Get(cultureInfo);
        }

        public static IEnumerable<IValueConverter> Get(CultureInfo cultureInfo)
        {            
            return new List<IValueConverter>
            {
                new StringConverter(),
                new LongConverter(cultureInfo.NumberFormat),
                new DateTimeConverter(cultureInfo.DateTimeFormat)
            };
        }
    }
}