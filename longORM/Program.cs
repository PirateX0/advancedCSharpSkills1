using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using longLibrary;


namespace longORM
{
    class Program
    {
        static void Main(string[] args)
        {
            MsSqlHelper.CreateConnection();
            Console.WriteLine("connect successfully!");

            Console.ReadKey();
        }
    }
}
