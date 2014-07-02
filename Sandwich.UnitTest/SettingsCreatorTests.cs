using System;
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
        private SettingsCreator _creator;

        public class MyTestSettings
        {
            public string StringValue { get; set; }
            public DateTime? NullableDateTime { get; set; }
            public DateTime DateTime { get; set; }
            public int Integer { get; set; }
            public int? NullableInteger { get; set; }
            public long Long { get; set; }
            public long? NullableLong { get; set; }
        }

        [TestFixtureSetUp]
        public void Setup()
        {
            _creator = new SettingsCreator(new ValueConverterFacade(new ConverterFactory(DefaultValueConverters.Get())));
        }

        [Test]
        public void Create_NullArgument_ReturnEmptySettings()
        {
            var settings = _creator.Create<MyTestSettings>(null);

            settings.StringValue.Should().BeNull();
            settings.NullableDateTime.Should().Be(null);
            settings.DateTime.Should().Be(DateTime.MinValue);
        }

        [Test]
        public void Create_EmptyArgumentList_ReturnEmptySettings()
        {
            var settings = _creator.Create<MyTestSettings>(new List<KeyValuePair<string, string>>
            {
                new KeyValuePair<string, string>("StringValue", "1")
            });

            settings.StringValue.Should().Be("1");
        }
    }

}
