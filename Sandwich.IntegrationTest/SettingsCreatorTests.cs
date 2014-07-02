using System;
using System.Collections.Generic;
using System.Globalization;
using FluentAssertions;
using NUnit.Framework;
using Sandwich.Core;
using Sandwich.Core.ValueConverters;

namespace Sandwich.IntegrationTest
{
    [TestFixture]
    public class SettingsCreatorTests
    {
        public class MySettings
        {
            public string Version { get; set; }
            public DateTime? ReleaseDate { get; set; }
            public bool EnableThisFeature { get; set; }
            public int MaxNumberOfUsers { get; set; }
            public float DefaultRate { get; set; }
            public IList<string> AvailableCultures { get; set; }
        }

        [Test]
        public void Test()
        {
            var settingsCreator = new SettingsCreator(new AppSettingsProvider.AppSettingsProvider(),
                DefaultValueConverters.CreateDefaultValueConverter(CultureInfo.GetCultureInfo("en-US")));

            var mySettings = settingsCreator.Create<MySettings>();

            mySettings.Version.Should().Be("1.0");
            mySettings.ReleaseDate.Should().Be(new DateTime(2014, 07, 01));
            mySettings.EnableThisFeature.Should().BeTrue();
            mySettings.MaxNumberOfUsers.Should().Be(15);
            mySettings.DefaultRate.Should().Be(13.37f);
            mySettings.AvailableCultures.Should().ContainInOrder(new[] {"nb-NO", "en-US"});
        }
    }
}
