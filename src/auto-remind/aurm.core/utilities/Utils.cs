using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace aurm.core.utilities
{
    public static class Utils
    {
        /// <summary>
        /// Throws an ArgumentNullException if <paramref name="o"/> is null
        /// and uses the <paramref name="name"/> variable as the "paramName" 
        /// call to the ArgumentNullException
        /// 
        /// Truth be told, I'm not 100% convinced of this function, but 
        /// I'm going to ride it out
        /// </summary>
        /// <param name="o"></param>
        /// <param name="name"></param>
        public static void ThrowIfNull(this object o, string name)
        {
            if(o == null)
            {
                throw new ArgumentNullException(name);
            }
        }
    }
}
