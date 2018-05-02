using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace longLibrary
{
    public static class LongExtensionFunction
    {
        public static bool IsBlank(this string s)
        {
            if (string.IsNullOrEmpty(s)) { return true; }

            return (s.Trim().Length == 0);
        }
    }
}
