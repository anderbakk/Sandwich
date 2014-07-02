using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Sandwich.Core.ValueConverters;

namespace Sandwich.Core
{
    public class SettingsCreator
    {
        private readonly ValueConverterFacade _valueConverterFacade;

        public SettingsCreator(ValueConverterFacade valueConverterFacade)
        {
            _valueConverterFacade = valueConverterFacade;
        }

        public T Create<T>(List<KeyValuePair<string, string>> settings) where T : new()
        {
            var settingsObject = new T();

            if (settings == null || settings.Count == 0)
                return settingsObject;

            var type = settingsObject.GetType();
            
            var properties = type.GetProperties();

            foreach (var property in properties)
            {
                var currentProperty = property;
                var matchingSetting = settings.FirstOrDefault(s => s.Key.Equals(currentProperty.Name, StringComparison.OrdinalIgnoreCase));

                if (!string.IsNullOrWhiteSpace(matchingSetting.Value))
                    ApplyValue(property, settingsObject, matchingSetting.Value);
            }

            return settingsObject;
        }

        private  void ApplyValue(PropertyInfo propertyInfo, object settingsObject, string value)
        {
            var targetType = propertyInfo.PropertyType;
            var propertyValue = _valueConverterFacade.ConvertValue(value, targetType);

            propertyInfo.SetValue(settingsObject, propertyValue);
        }
    }
}
