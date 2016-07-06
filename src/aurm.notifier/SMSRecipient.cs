using aurm.core.notifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using aurm.core.utilities;
using System.Text.RegularExpressions;

namespace aurm.notifier
{
    public class SMSRecipient : Recipient
    {
        private const string _phoneRegexPattern = @"\(?\d{3}\)?-? *\d{3}-? *-?\d{4}";

        public string PhoneNumber { get; private set; }

        public SMSRecipient(string name, string phoneNumber)
            : base(name)
        {
            phoneNumber.ThrowIfNull(nameof(phoneNumber));

            //Need to regex this out and make sure its a valid phone number
            if(!Regex.IsMatch(phoneNumber,_phoneRegexPattern))
            {
                throw new ArgumentException($"The phone number: {phoneNumber} was not a valid phone number");
            }
            PhoneNumber = phoneNumber;
        }
    }
}
