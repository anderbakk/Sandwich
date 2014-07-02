using System;
using System.Collections.Generic;
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
                new ValueConverterFacade(new ConverterFactory(DefaultValueConverters.GetAll(cultureInfo)));
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
        public void ConvertValue_WithIntValue_IsConverted()
        {
            var valueConverter = GetValueConverterFacade(_usCultureInfo);
            var result = valueConverter.ConvertValue<int>(int.MaxValue.ToString());
            result.Should().Be(int.MaxValue);
        }

        [Test]
        public void ConvertValue_WithHexCharValue_IsConverted()
        {
            var valueConverter = GetValueConverterFacade(_usCultureInfo);
            var result = valueConverter.ConvertValue<char>("61");
            result.Should().Be('a');
        }

        [Test]
        public void ConvertValue_WithCharValue_IsConverted()
        {
            var valueConverter = GetValueConverterFacade(_usCultureInfo);
            var result = valueConverter.ConvertValue<char>("a");
            result.Should().Be('a');
        }

        [Test]
        public void ConvertValue_WithBoolTrueValue_IsConverted()
        {
            var valueConverter = GetValueConverterFacade(_usCultureInfo);
            var result = valueConverter.ConvertValue<bool>("true");
            result.Should().BeTrue();
        }

        [Test]
        public void ConvertValue_WithFloatValue_IsConverted()
        {
            var valueConverter = GetValueConverterFacade(_usCultureInfo);
            var result = valueConverter.ConvertValue<float>("13.37");
            result.Should().Be(13.37f);
        }

        [Test]
        public void ConvertValue_WithDecimaleValue_IsConverted()
        {
            var valueConverter = GetValueConverterFacade(_usCultureInfo);
            var result = valueConverter.ConvertValue<decimal>("65.537");
            result.Should().Be(65.537m);
        }

        [Test]
        public void ConvertValue_WithDoubleValue_IsConverted()
        {
            var valueConverter = GetValueConverterFacade(_usCultureInfo);
            var result = valueConverter.ConvertValue<double>("78.557");
            result.Should().Be(78.557d);
        }

        [Test]
        public void ConvertValue_WithByteValue_IsConverted()
        {
            var valueConverter = GetValueConverterFacade(_usCultureInfo);
            var result = valueConverter.ConvertValue<byte>("255");
            result.Should().Be(255);
        }

        [Test]
        public void ConvertValue_WithNullableIntValue_IsConverted()
        {
            var valueConverter = GetValueConverterFacade(_usCultureInfo);
            var result = valueConverter.ConvertValue<int?>(int.MaxValue.ToString());
            result.Should().Be(int.MaxValue);
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

        [Test]
        public void ConvertValue_ArrayOfString_IsConverted()
        {
            var valueConverter = GetValueConverterFacade(_noCultureInfo);

            var result = valueConverter.ConvertValue<string[]>("a,b,c");
            result.Should().ContainInOrder(new[] {"a", "b", "c"});
        }

        [Test]
        public void ConvertValue_IListOfString_IsConverted()
        {
            var valueConverter = GetValueConverterFacade(_noCultureInfo);

            var result = valueConverter.ConvertValue<IList<string>>("a,b,c");
            result.Should().ContainInOrder(new[] { "a", "b", "c" });
        }
    }
}
