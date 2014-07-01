using System;
using System.Globalization;
using FluentAssertions;
using NUnit.Framework;
using Sandwich.Core.ValueConverters;

namespace Sandwich.UnitTest.ValueConverters
{
    [TestFixture]
    public class ValuesConverterTests
    {
        private readonly CultureInfo _usCultureInfo = CultureInfo.GetCultureInfo("en-US");
        private readonly CultureInfo _noCultureInfo = CultureInfo.GetCultureInfo("nb-NO");

        private static ValueConverterFacade GetValueConverterFacade(CultureInfo cultureInfo)
        {
            var valueConverter =
                new ValueConverterFacade(new ConverterFactory(DefaultValueConverters.Get(cultureInfo)));
            return valueConverter;
        }

        [Test]
        public void ConvertValue_WithStringValue_IsConverted()
        {
            var valueConverter = GetValueConverterFacade(_usCultureInfo);

            var result = valueConverter.ConvertValue<string>("a string value");
            result.Should().Be("a string value");
        }

        [Test]
        public void ConvertValue_WithLongValue_IsConverted()
        {
            var valueConverter = GetValueConverterFacade(_usCultureInfo);

            var result = valueConverter.ConvertValue<long>(long.MaxValue.ToString());
            result.Should().Be(long.MaxValue);
        }

        [Test]
        public void ConvertValue_WithNullableLongValue_IsConverted()
        {
            var valueConverter = GetValueConverterFacade(_usCultureInfo);

            var result = valueConverter.ConvertValue<long?>("1000");
            result.Should().Be(1000);
        }

        [Test]
        public void ConvertValue_WithDateTimeValue_IsConverted()
        {
            var valueConverter = GetValueConverterFacade(_usCultureInfo);

            var result = valueConverter.ConvertValue<DateTime>("2014-07-01");
            result.Should().Be(new DateTime(2014, 07, 01));
        }

        [Test]
        public void ConvertValue_WithNorwegianDateTimeValueAndCulture_IsConverted()
        {
            var valueConverter = GetValueConverterFacade(_noCultureInfo);

            var result = valueConverter.ConvertValue<DateTime>("01.07.2014");
            result.Should().Be(new DateTime(2014, 07, 01));
        }
    }
}
