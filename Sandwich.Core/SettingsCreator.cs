using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Sandwich.Core.Interface;

namespace Sandwich.Core
{
    public class SettingsCreator
    {
        private readonly IProvideSettings[] _settingsProviders;
        private readonly IConvertValues _valueConverter;

        public SettingsCreator(IProvideSettings[] settingsProviders, IConvertValues valueConverter)
        {
            _settingsProviders = settingsProviders;
            _valueConverter = valueConverter;
        }

        public SettingsCreator(IProvideSettings settingsProvider, IConvertValues valueConverter)
        {
            _settingsProviders = new[]{settingsProvider};
            _valueConverter = valueConverter;
        }

        public T Create<T>() where T : new()
        {
            var settings = GetSettingsFromProviders();

            var settingsObject = new T();

            if (!settings.Any())
                return settingsObject;

            var propertiesInSettingsObject = settingsObject.GetType().GetProperties();

            foreach (var property in propertiesInSettingsObject)
            {
                var currentProperty = property;
                if(currentProperty.GetSetMethod(false) == null)
                    continue;

                var matchingSetting = settings.FirstOrDefault(s => s.Key.Equals(currentProperty.Name, StringComparison.OrdinalIgnoreCase));

                if (!string.IsNullOrWhiteSpace(matchingSetting.Value))
                    ApplyValue(property, settingsObject, matchingSetting.Value);
            }

            return settingsObject;
        }

        private IList<KeyValuePair<string, string>> GetSettingsFromProviders()
        {
            var allSettings = new List<KeyValuePair<string, string>>();

            foreach (var settingsProvider in _settingsProviders)
            {
                allSettings.AddRange(settingsProvider.GetSettings());
            }
            return allSettings;
        }

        private  void ApplyValue(PropertyInfo propertyInfo, object settingsObject, string value)
        {
            var targetType = propertyInfo.PropertyType;
            var propertyValue = _valueConverter.ConvertValue(value, targetType);

            propertyInfo.SetValue(settingsObject, propertyValue);
        }
    }
}
