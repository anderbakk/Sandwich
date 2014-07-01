using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Sandwich.Core
{
    public class SettingsCreator
    {
        public T Create<T>(List<KeyValuePair<string, string>> settings) where T : new()
        {
            var settingsObject = new T();

            var type = settingsObject.GetType();
            
            var properties = type.GetProperties();

            foreach (var property in properties)
            {
                var currentProperty = property;
                var matchingSetting = settings.FirstOrDefault(s => s.Key.Equals(currentProperty.Name, StringComparison.OrdinalIgnoreCase));

                ApplyValue(property, settingsObject, matchingSetting);
            }

            return settingsObject;
        }

        private static void ApplyValue(PropertyInfo propertyInfo, object settingsObject, KeyValuePair<string, string> matchingSetting)
        {
            var targetType = propertyInfo.PropertyType;

            propertyInfo.SetValue(settingsObject, matchingSetting.Value);
        }
    }
}
