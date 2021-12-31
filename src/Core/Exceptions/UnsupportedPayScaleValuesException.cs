using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
