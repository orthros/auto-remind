using aurm.core.notifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using aurm.core.utilities;

namespace aurm.core.tasks
{
    public class AurmTask
    {
        public AurmTask(Guid uiD, Recipient recipient, 
                        string message, TimeCondition timeCondition, List<ICondition> additionalConditions)
        {
            recipient.ThrowIfNull(nameof(recipient));
            timeCondition.ThrowIfNull(nameof(timeCondition));
            additionalConditions.ThrowIfNull(nameof(additionalConditions));
            
            if(string.IsNullOrWhiteSpace(message))
            {
                throw new ArgumentException($"Parameter {nameof(message)} must not be null or whitespace", 
                                            nameof(message));
            }
            UiD = uiD;
            Recipient = recipient;
            TimeCondition = timeCondition;
            AdditionalConditions = additionalConditions;
            Message = message;

            LastTriggeredTime = DateTime.MinValue;
        }

        public Guid UiD { get; private set; }

        public Recipient Recipient { get; private set; }

        public string Message { get; set; }

        public TimeCondition TimeCondition { get; private set; }

        public List<ICondition> AdditionalConditions { get; private set; }

        public DateTime LastTriggeredTime { get; set; }

    }
}
