using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using longLibrary;


namespace LongORM
{
    class Program
    {
        static void Main(string[] args)
        {
            //using (MySqlHelper.CreateConnection())
            //{
            //    Console.WriteLine("连接成功");
            //}

            //Person p = new Person();
            //p.Name = "long";
            //p.Age = 1;
            //LongORM.Insert(p);
            //Console.WriteLine("insert successfully");



            //Person p = new Person();
            //p.Name = "李小龙";
            //p.Age = 99;
            //int i = LongORM.Insert(p);
            //if (i <= 0)
            //{
            //    Console.WriteLine("插入失败");
            //}
            //else
            //{
            //    Console.WriteLine("插入成功");
            //}

            //Person p = LongORM.SelectById<Person>(1);
            //if (p == null)
            //{
            //    Console.WriteLine("抱歉，没有找到");
            //}
            //else
            //{
            //    Console.WriteLine(p.Id + p.Name + p.Age);
            //}

            //int i = LongORM.DeleteById<Person>(1);
            //if (i <= 0)
            //{
            //    Console.WriteLine("不存在该数据");
            //}
            //else
            //{
            //    Console.WriteLine("删除成功");
            //}

            Person p = new Person();
            p.Id = 2;
            p.Name = "李小龙";
            p.Age = 99;
            int i = LongORM.Update(p);
            if (i <= 0)
            {
                Console.WriteLine("不存在该数据");
            }
            else
            {
                Console.WriteLine("更新成功");
            }


            Console.ReadKey();
        }
    }
}
