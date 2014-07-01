using FluentAssertions;
using NUnit.Framework;
using Sandwich.Core.ValueConverters;

namespace Sandwich.UnitTest.ValueConverters
{
    [TestFixture]
    public class ValuesConverterTests
    {
        [Test]
        public void ConvertValue_WithStringValue_IsConverted()
        {
            var valueConverter = new ValueConverter(new ConverterFactory(DefaultValueConverters.Get()));

            var result = valueConverter.ConvertValue<string>("a string value");
            result.Should().Be("a string value");
        }

        [Test]
        public void ConvertValue_WithLongValue_IsConverted()
        {
            var valueConverter = new ValueConverter(new ConverterFactory(DefaultValueConverters.Get()));

            var result = valueConverter.ConvertValue<long>(long.MaxValue.ToString());
            result.Should().Be(long.MaxValue);
        }

        [Test]
        public void ConvertValue_WithNullableLongValue_IsConverted()
        {
            var valueConverter = new ValueConverter(new ConverterFactory(DefaultValueConverters.Get()));

            var result = valueConverter.ConvertValue<long?>("1000");
            result.Should().Be(1000);
        }
    }
}
