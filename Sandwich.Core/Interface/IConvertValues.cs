using System;

namespace Sandwich.Core.Interface
{
    public interface IConvertValues
    {
        object ConvertValue(string value, Type type);
    }
}