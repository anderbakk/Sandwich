using System;
using System.Collections.Generic;

namespace Sandwich.Core.Interface
{
    public interface IValueConverter
    {
        object Convert(string value);

        IEnumerable<Type> SupportedTypes { get; } 
    }
}