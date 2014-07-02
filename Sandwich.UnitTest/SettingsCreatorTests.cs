using System;
using System.Collections.Generic;
using System.Globalization;
using FluentAssertions;
using Moq;
using NUnit.Framework;
using Sandwich.Core;
using Sandwich.Core.Interface;
using Sandwich.Core.ValueConverters;

namespace Sandwich.UnitTest
{
    [TestFixture]
    public class SettingsCreatorTests
    {
        private SettingsCreator _creator;
        private Mock<IProvideSettings> _settingsProviderStub;

        public class MyTestSettings
        {
            public string StringValue { get; set; }
            public DateTime? NullableDateTime { get; set; }
            public DateTime DateTime { get; set; }
            public int Integer { get; set; }
            public int? NullableInteger { get; set; }
            public long Long { get; set; }
            public long? NullableLong { get; set; }

            public string StringValueWithPrivateSet { get; private set; }
        }

        [TestFixtureSetUp]
        public void Setup()
        {
            _settingsProviderStub = new Mock<IProvideSettings>();
            _creator = new SettingsCreator(new[] {_settingsProviderStub.Object},
                new ValueConverterFacade(new ConverterFactory(DefaultValueConverters.GetAll(CultureInfo.GetCultureInfo("en-US")))));
        }

        [Test]
        public void Create_EmptyArgumentList_ReturnEmptySettings()
        {
            _settingsProviderStub.Setup(s => s.GetSettings()).Returns(new List<KeyValuePair<string, string>>());
            var settings = _creator.Create<MyTestSettings>();

            settings.StringValue.Should().BeNull();
            settings.NullableDateTime.Should().Be(null);
            settings.DateTime.Should().Be(DateTime.MinValue);
        }

        [Test]
        public void Create_GetSettingsReturnsStringValue_ReturnSettingsObjectWithStringValue()
        {
            _settingsProviderStub.Setup(s => s.GetSettings()).Returns(new List<KeyValuePair<string, string>>
            {
                new KeyValuePair<string, string>("StringValue", "1")
            });

            var settings = _creator.Create<MyTestSettings>();

            settings.StringValue.Should().Be("1");
        }

        [Test]
        public void Create_SettingsFieldWithPrivateSet_FieldIsIgnored()
        {
            _settingsProviderStub.Setup(s => s.GetSettings()).Returns(new List<KeyValuePair<string, string>>
            {
                new KeyValuePair<string, string>("StringValueWithPrivateSet", "1")
            });

            var settings = _creator.Create<MyTestSettings>();

            settings.StringValueWithPrivateSet.Should().BeNull();
        }
    }

}
