using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelegateLambdaEvent
{
    class Program
    {
        static void Main(string[] args)
        {
            #region is,as
            //object i = 5;
            //Console.WriteLine(i is ValueType);
            //Console.WriteLine(i as int); 
            #endregion

            #region delegate
            //Say s = Chinese;
            //s();
            //s = English;
            //s();
            //s += Chinese;
            //s();
            //Speak(Chinese); 
           

            //int[] nums = { 1,2,3,4,5};
            //int max = GetMax(nums);
            //Console.WriteLine(max);

            //object[] nums = { 1, 2, 3, 4, 5 };
            //object max = GetMax(nums, isFirstBigInt);
            //Console.WriteLine(max);

            //Person[] persons = {new Person{Age=18,Name="dalong"},new Person{Age=100,Name="ava"}};
            //Person person = GetMax(persons,isFirstBigPerson) as Person;
            //Console.WriteLine("name="+person.Name+",age="+person.Age);
            #endregion


            #region 泛型委托
            //int[] nums = { 1, 2, 3, 4, 5 };
            //int max = GetMax(nums, isFirstBigInt);
            //Console.WriteLine(max);

            //Person[] persons = { new Person { Age = 18, Name = "dalong" }, new Person { Age = 100, Name = "ava" } };
            //Person person = GetMax(persons, isFirstBigPerson);
            //Console.WriteLine("name=" + person.Name + ",age=" + person.Age); 
            #endregion

            #region 内置委托
            //Action a = Chinese;
            //a();
            //Func<int, int, bool> d = isFirstBigInt;
            //Console.WriteLine(d(2, 5)); ; 
            #endregion

            int[] nums = { 1, 2, 3, 4, 5 };
            IsFirstBigFunc<int> f = delegate(int i,int j)
            {
                return i > j;
            };
            int max = GetMax(nums, f);
            Console.WriteLine(max);

            Console.ReadKey();


        }

        //static int GetMax(int[] nums)
        //{
        //    int max = nums[0];
        //    for (int i = 0; i < nums.Length; i++)
        //    {
        //        if (max<nums[i])
        //        {
        //            max = nums[i];
        //        }
        //    }
        //    return max;
        //}

        //static object GetMax(object[] objList, IsFirstBigFunc func)
        //{
        //    object max = objList[0];
        //    for (int i = 0; i < objList.Length; i++)
        //    {
        //        if (func(objList[i],max))
        //        {
        //            max = objList[i];
        //        }
        //    }
        //    return max;
        //}

        static T GetMax<T>(T[] objList, IsFirstBigFunc<T> func)
        {
            T max = objList[0];
            for (int i = 0; i < objList.Length; i++)
            {
                if (func(objList[i], max))
                {
                    max = objList[i];
                }
            }
            return max;
        }

        //static bool isFirstBigInt(object o1,object o2)
        //{
        //    if ((int)o1>(int)o2)
        //    {
        //        return true;
        //    }
        //    return false;
        //}

        static bool isFirstBigInt(int o1, int o2)
        {
            
            if (o1 > o2)
            {
                return true;
            }
            return false;
        }

        //static bool isFirstBigPerson(object o1, object o2)
        //{
        //    Person p1 = (Person)o1;
        //    Person p2 = (Person)o2;
        //    if (p1.Age > p2.Age)
        //    {
        //        return true;
        //    }
        //    return false;
        //}

        static bool isFirstBigPerson(Person p1, Person p2)
        {
            if (p1.Age > p2.Age)
            {
                return true;
            }
            return false;
        }

        static void Speak(Say s)
        {
            s();
        }

        static void Chinese()
        {
            Console.WriteLine("chinese"); ;
        }

        static void English()
        {
            Console.WriteLine("english"); 
        }
    }

    class Person
    {
        public string Name { get; set; }
        public int Age { get; set; }
    }

    delegate void Say();
    delegate bool IsFirstBigFunc(object o1, object o2);
    delegate bool IsFirstBigFunc<T>(T t1,T t2);

}
