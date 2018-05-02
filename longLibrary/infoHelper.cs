using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace longLibrary
{
    public class infoHelper
    {
        public static string ShowAuthor()
        {
            return "long";
        }

        public static string GetConStr()
        {
            return ConfigurationManager.ConnectionStrings["conStr"].ConnectionString;
        }

        public string this[int index]
        {
            get
            { 
                return index+"";
            }
            set
            {
                Console.WriteLine("set successfully: "+value);
            }
        }
        public string this[string name]
        {
            get
            {
                return name + "";
            }
            set
            {
                Console.WriteLine("set successfully: " + value);
            }
        }
    }
}
