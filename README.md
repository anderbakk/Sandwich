#Sandwich
========

Sandwich creates a strongly typed configuration file to use in your application. Using reflection, the appsettings will automatically get mapped to the properties of the specified configuration file. The value from the configuration file will created according to the type of target property. 

This allows your application to become more testable since it does not depend upon having a configuration file present, and it is easy to change where the configuration is set.

##Example
You have the following settings defined in app.config:
  &lt;appSettings&gt;
    &lt;add key="Version" value="1.0"/&gt;
    &lt;add key="ReleaseDate" value="2014-07-01"/&gt;
    &lt;add key="EnableThisFeature" value="true"/&gt;
    &lt;add key="MaxNumberOfUsers" value="15"/&gt;
    &lt;add key="DefaultRate" value="13.37"/&gt;
    &lt;add key="AvailableCultures" value="nb-NO,en-US"/&gt;
  &lt;/appSettings&gt; 

Using settingsCreator.Create<MySettings>() will create an instance of MySettings with all matching properties filled.

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

