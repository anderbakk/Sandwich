using System.Collections.Generic;
using FluentAssertions;
using NUnit.Framework;
using Sandwich.Core;
using Sandwich.Core.ValueConverters;

namespace Sandwich.UnitTest
{
    [TestFixture]
    public class SettingsCreatorTests
    {
        public class MyTestSettings
        {
            public string Version { get; set; }
        }

        [Test]
        public void Test()
        {
            var creator = new SettingsCreator();

            var settings = creator.Create<MyTestSettings>(new List<KeyValuePair<string, string>>
            {
                new KeyValuePair<string, string>("Version", "1")
            });

            settings.Version.Should().Be("1");
        }
    }

    [TestFixture]
    public class ConverterTests
    {
        [Test]
        public void LongConverterTest()
        {
            var longConverter = new LongConverter();
            var result = longConverter.Convert("1");

            result.Should().Be(1);
        }

        [Test]
        public void MaxValue()
        {
            var maxLong = long.MaxValue.ToString();
            var longConverter = new LongConverter();
            var result = longConverter.Convert(maxLong);

            result.Should().Be(long.MaxValue);

        }
    }
}
