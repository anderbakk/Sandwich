using System;

namespace Sandwich.Core.Exceptions
{
    public class ValueConversionNotSupportedException : Exception
    {
        public ValueConversionNotSupportedException()
        {
        }

        public ValueConversionNotSupportedException(string message)
            : base(message)
        {
        }

        public ValueConversionNotSupportedException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
