using System.Collections.Generic;
using Sandwich.Core.Interface;

namespace Sandwich.Core.ValueConverters
{
    public static class DefaultValueConverters
    {
        public static IEnumerable<IValueConverter> Get()
        {
            return new List<IValueConverter>
            {
                new StringConverter(),
                new LongConverter(),
                new DateTimeConverter()
            };
        }
    }
}