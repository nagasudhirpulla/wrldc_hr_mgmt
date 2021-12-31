using Core.Common;
using Core.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.ValueObjects
{
    public class PayScale : ValueObject
    {
        public int LowVal { get; private set; } = 0;
        public int HighVal { get; private set; } = 0;

        public PayScale(int lowVal, int highVal)
        {
            if (lowVal < 0 || highVal < 0)
            {
                throw new NegativePayScaleValuesException(lowVal, highVal);
            }
            if (lowVal > highVal)
            {
                throw new UnsupportedPayScaleValuesException(lowVal, highVal);
            }
            HighVal = highVal;
            LowVal = lowVal;
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return LowVal;
            yield return HighVal;
        }
    }
}
