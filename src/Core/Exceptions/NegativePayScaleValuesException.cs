using System;

namespace Core.Exceptions
{
    public class NegativePayScaleValuesException : Exception
    {
        public NegativePayScaleValuesException(int lowVal, int highVal)
            : base($"Negative pay scale values not supported, the supplied values were low={lowVal}, high={highVal}")
        {
        }
    }
}
