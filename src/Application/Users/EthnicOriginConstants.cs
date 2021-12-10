using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Users
{
    public class EthnicOriginConstants
    {
        public const string SC = "SC";
        public const string ST = "ST";
        public const string GEN = "General";
        public const string OBC = "OBC";
        public const string EWS = "EWS";


        public static List<string> GetEthnicOriginOptions()
        {
            return typeof(EthnicOriginConstants).GetFields().Select(x => x.GetValue(null).ToString()).ToList();
        }
    }
}
