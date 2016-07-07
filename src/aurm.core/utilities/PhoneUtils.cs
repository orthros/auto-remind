using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace aurm.core.utilities
{
    public static class PhoneUtils
    {
        private const string _phoneRegexPattern = @"^\(?\d{3}\)?-? *\d{3}-? *-?\d{4}$";
        
        public static bool IsValidNumber(string phoneNumber)
        {
            //Need to regex this out and make sure its a valid phone number
            if (!Regex.IsMatch(phoneNumber, _phoneRegexPattern, RegexOptions.Singleline))
            {
                return false;
            }
            return true;
        }
    }
}
