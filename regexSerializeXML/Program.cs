using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace regexSerializeXML
{
    class Program
    {
        static void Main(string[] args)
        {
            #region 正则表达式
            //string input ="2018-5-10";
            //string pattern = @"^(\d{4})\-(\d{1,2})\-(\d{1,2})$";
            //Console.WriteLine(Regex.IsMatch(input, pattern));

            //Match match =Regex.Match(input ,pattern);
            //Console.WriteLine(match.Value);
            //foreach (Group group in match.Groups)
            //{
            //    Console.WriteLine(group.Value);
            //}       
            #endregion

            Person person = new Person { Name="long",Age=18};

            BinaryFormatter binaryFormatter = new BinaryFormatter();
            using (FileStream fs=new FileStream("c:/test/",FileMode.OpenOrCreate))
            {
                //StreamWriter
                //StreamReader
            }

            Console.ReadKey();
        }
    }
    class Person
    {
        public string Name { get; set; }
        public int Age { get; set; }
    }
}
