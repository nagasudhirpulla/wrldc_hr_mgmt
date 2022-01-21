using System;

namespace Core.Exceptions
{
    public class UnsupportedPayScaleValuesException : Exception
    {
        public UnsupportedPayScaleValuesException(int lowVal, int highVal)
            : base($"Unsupported pay scale values provided, the supplied values were low={lowVal}, high={highVal}")
        {
        }
    }
}
