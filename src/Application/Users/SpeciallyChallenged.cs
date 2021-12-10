using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Users
{
    public class SpeciallyChallenged
    {
        public const string OH = "OH";
        public const string HH = "HH";
        public const string VH = "VH";
        

        public static List<string> GetSpeciallyChallengedOptions()
        {
            return typeof(SpeciallyChallenged).GetFields().Select(x => x.GetValue(null).ToString()).ToList();
        }
    }
}
