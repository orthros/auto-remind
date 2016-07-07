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
        
        public string PhoneNumber { get; private set; }

        public SMSRecipient(string name, string phoneNumber)
            : base(name)
        {
            phoneNumber.ThrowIfNull(nameof(phoneNumber));

            if(!PhoneUtils.IsValidNumber(phoneNumber))
            {
                throw new ArgumentException($"The phone number: {phoneNumber} was not a valid phone number");
            }

            PhoneNumber = phoneNumber;
        }
    }
}
