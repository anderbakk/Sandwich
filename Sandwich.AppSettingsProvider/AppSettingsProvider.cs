using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using Sandwich.Core.Interface;

namespace Sandwich.AppSettingsProvider
{
    public class AppSettingsProvider : IProvideSettings
    {
        public IEnumerable<KeyValuePair<string, string>> GetSettings()
        {
            var keys = ConfigurationManager.AppSettings.AllKeys;

            return keys.Select(key => new KeyValuePair<string, string>(key, ConfigurationManager.AppSettings[key]));
        }
    }
}
