using Ardalis.SmartEnum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Enums
{
    public sealed class GenderEnum : SmartEnum<GenderEnum>
    {
        public static readonly GenderEnum Male = new(nameof(Male), 1);
        public static readonly GenderEnum Female = new(nameof(Female), 2);

        private GenderEnum(string name, int value) : base(name, value)
        {
        }
    }
}
