using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using aurm.core.utilities;

namespace aurm.core.notifications
{
    public abstract class Recipient
    {
        public string Name { get; private set; }

        public Recipient(string name)
        {
            name.ThrowIfNull(nameof(name));

            this.Name = name;
        }
    }
}
