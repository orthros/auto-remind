using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace aurm.core.notifications
{
    public interface INotifier
    {
        void Notify(Recipient rec, string message);
    }
}
