using aurm.core.notifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Twilio;
using System.Configuration;
using RestSharp;
using aurm.core.utilities;

namespace aurm.notifier
{
    public class TwilioNotifier : INotifier
    {
        private const string _twilioAuthKey_Key = "twilio-auth-key";
        private const string _twilioAuthToken_Key = "twilio-auth-token";
        private const string _twilioFromNumber_Key = "twilio-from-number";

        public string AuthKey { get; private set; }
        public string AuthToken { get; private set; }
        public string FromNumber { get; private set; }

        public TwilioNotifier()
        {
            if (!ConfigurationManager.AppSettings.HasKeys())
            {
                throw new ConfigurationErrorsException("No keys configured for Twilio Authentication and number");
            }

            AuthKey = ConfigurationManager.AppSettings[_twilioAuthKey_Key];
            AuthToken = ConfigurationManager.AppSettings[_twilioAuthToken_Key];
            FromNumber = ConfigurationManager.AppSettings[_twilioFromNumber_Key];

            bool nullAuth = string.IsNullOrWhiteSpace(AuthKey);
            bool nullToken = string.IsNullOrWhiteSpace(AuthToken);

            bool invalidNumber = !PhoneUtils.IsValidNumber(FromNumber);

            if (nullAuth || nullToken || invalidNumber)
            {
                string message = "Building the TwilioNotifier failed; The following messages were found:\n";
                List<string> errors = new List<string>();
                if (nullAuth)
                {
                    errors.Add($"The authentication key set by {_twilioAuthKey_Key} was null");
                }
                if (nullToken)
                {
                    errors.Add($"The authentication token set by {_twilioAuthToken_Key} was null");
                }
                if (invalidNumber)
                {
                    errors.Add($"The phone number set by {_twilioFromNumber_Key} was not a valid phone number");
                }
                throw new InvalidOperationException(string.Concat(message, string.Join("\n", errors)));
            }
        }

        public void Notify(Recipient rec, string message)
        {
            rec.ThrowIfNull(nameof(rec));

            var smsRec = rec as SMSRecipient;
            if(smsRec == null)
            {
                throw new ArgumentException("Recepient must be a SMSRecipient");
            }
            
            TwilioRestClient trc = new TwilioRestClient(AuthKey,AuthToken);

            trc.SendMessage(FromNumber, smsRec.PhoneNumber, message);
            
        }
    }
}
