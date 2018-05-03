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

        public static IEnumerable<T> LongWhere<T>(this IEnumerable<T> collection, Func<T, bool> filter)
        {
            List<T> list = new List<T>();
            foreach (var item in collection)
            {
                if (filter(item))
                {
                    list.Add(item);
                }
            }
            return list;
        }
    }
}
