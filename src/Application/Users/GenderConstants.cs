using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Users
{
    public class GenderConstants
    {
        public const string MALE = "Male";
        public const string FEMALE = "Female";
        

        public static List<string> GetGenderOptions()
        {
            return typeof(GenderConstants).GetFields().Select(x => x.GetValue(null).ToString()).ToList();
        }
    }
}
