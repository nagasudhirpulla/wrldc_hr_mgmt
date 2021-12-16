using Ardalis.SmartEnum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Enums
{
    public sealed class EthnicOriginEnum : SmartEnum<EthnicOriginEnum>
    {
        public static readonly EthnicOriginEnum SC = new(nameof(SC), 1);
        public static readonly EthnicOriginEnum ST = new(nameof(ST), 2);
        public static readonly EthnicOriginEnum General = new(nameof(General), 3);
        public static readonly EthnicOriginEnum OBC = new(nameof(OBC), 4);
        public static readonly EthnicOriginEnum EWS = new(nameof(EWS), 5);

        private EthnicOriginEnum(string name, int value) : base(name, value)
        {
        }
    }
}
