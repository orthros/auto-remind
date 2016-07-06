using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace aurm.core.notifications
{
    public abstract class Recipient
    {
        public string Name { get; private set; }
    }
}
