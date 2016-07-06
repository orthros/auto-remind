using aurm.core.notifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Twilio;

namespace aurm.notifier
{
    public class TwilioNotifier : INotifier
    {
        public void Notify(Recipient rec, string message)
        {
            TwilioRestClient trc = new TwilioRestClient("", "");
            throw new NotImplementedException();
        }
    }
}
