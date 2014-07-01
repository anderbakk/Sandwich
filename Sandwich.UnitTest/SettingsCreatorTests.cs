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

}
