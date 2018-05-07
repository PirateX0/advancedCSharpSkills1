using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using longLibrary;

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

            #region 匿名方法
            //int[] nums = { 1, 2, 3, 4, 5 };
            //IsFirstBigFunc<int> f = delegate(int i,int j)
            //{
            //    return i > j;
            //};
            //int max = GetMax(nums, f);
            //Console.WriteLine(max); 
            #endregion

            #region lambda
            //Func<int, int, bool> f = delegate(int i, int j) { return i > j; };
            //Func<int, int, bool> f2 = (int i, int j) => { return i > j; };
            //Func<int, int, bool> f3=(i,j)=>{return i>j;};
            //Func<int, int, bool> f4 = (i, j) => i > j;
            //int[] nums = { 1, 2, 3, 4, 5 };
            //Console.WriteLine(GetMax(nums,f4));

            //Func<int, int> f5 = i => i * i;
            //Console.WriteLine(f5(6));

            //Action<string, bool> a1 = delegate(string s, bool b)
            //{
            //    if (b) { Console.WriteLine("true" + s); }
            //    else { Console.WriteLine("false" + s); }
            //};
            //Action<string, bool> a2 = ( s,  b)=>
            //{
            //    if (b) { Console.WriteLine("true" + s); }
            //    else { Console.WriteLine("false" + s); }
            //};
            //a1("haha",true);
            //a2("haha", true);

            //Func<string, int> f1 = delegate(string str) { return Convert.ToInt32(str); };
            //Func<string, int> f2 = str=>Convert.ToInt32(str);
            //Console.WriteLine(f1("666")); ;
            //Console.WriteLine(f2("666")); ;

            //Action<string, int> a11 = (s1, i1) => { Console.WriteLine("s1=" + s1 + ",i1=" + i1); };
            //Action<string, int> a112 = delegate (string s1,int i1) { Console.WriteLine("s1=" + s1 + ",i1=" + i1); };

            //Func<int, string> f12 = n => (n + 1).ToString();
            //Func<int, string> f13 = delegate(int n){ return (n + 1).ToString();};

            //Func<int, int> f14 = n => n * 2;
            //Func<int, int> f15 = delegate(int n) { return n * 2; };

            //Console.WriteLine(f15(20));

            //Func<int, bool> f = n => n > 0;
            //Console.WriteLine(f(3));

            //int[] nums = { 1,2,3,4,5,6};
            //int max = GetMax(nums,(i,j)=>i>j);
            //Console.WriteLine(max);

            //Person[] persons = { new Person{Age=18,Name="dalong"},new Person{Age=50,Name="dad"}};
            //Person person = GetMax(persons,(i,j)=>i.Age>j.Age);
            //Console.WriteLine(person.Age+" "+person.Name);

            //int[] nums = { 1,2,3,4,5};
            //foreach (var item in nums.LongWhere(i=>i>3))
            //{
            //    Console.WriteLine(item);
            //} 
            #endregion

            #region 集合常用扩展方法
            //int[] nums = { 1, 4,2,4 ,5, 6 };
            //IEnumerable<int> numsQuery = nums.Where(i=>i>3);
            //foreach (var item in numsQuery)
            //{
            //    Console.WriteLine(item);
            //}
            //IEnumerable<int> numsQuery2 = nums.Select(i => i*2);
            //foreach (var item in numsQuery2)
            //{
            //    Console.WriteLine(item);
            //}
            //Console.WriteLine(numsQuery2.Max()+","+numsQuery2.Min());
            //foreach (var item in numsQuery2.OrderBy(i=>i))
            //{
            //    Console.WriteLine(item);
            //}
            //Console.WriteLine(numsQuery2.OrderBy(i => i).First());

            //var list=numsQuery2.ToList();
            //list.Add(1);
            //Console.WriteLine(list.Min());

            //Person[] persons = { new Person{Name="long",Age=5},new Person{Name="jie",Age=18}};
            //Console.WriteLine(persons.Sum(p=>p.Age));
            //Console.WriteLine(persons.OrderByDescending(p=>p.Age).First().Name); 

            //bool[] bools = { };
            //Console.WriteLine(bools.SingleOrDefault());

            //Console.WriteLine(Convert.ToBoolean(0));

            #endregion

            #region 委托组合
            //Action a = new Action(() => { Console.WriteLine("1;"); }) + new Action(() => { Console.WriteLine("2"); });
            //a();
            //a = () => { Console.WriteLine("3"); };
            //a();
            //a += () => { Console.WriteLine("4"); };
            //a(); 
            #endregion

            #region 事件
            //Person p = new Person();
            //p.OnBenMingNian += () => { Console.WriteLine("ben ming nian, good luck!"); };
            ////p.OnBenMingNian();
            ////p.OnBenMingNian = null;
            //p.Age = 5;
            //Console.WriteLine(p.Age);
            //p.Age = 12;
            //Console.WriteLine(p.Age); 
            #endregion

         

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

        //static T GetMax<T>(T[] objList, IsFirstBigFunc<T> func)
        //{
        //    T max = objList[0];
        //    for (int i = 0; i < objList.Length; i++)
        //    {
        //        if (func(objList[i], max))
        //        {
        //            max = objList[i];
        //        }
        //    }
        //    return max;
        //}

        static T GetMax<T>(T[] objList, Func<T,T,bool> func)
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
        private int age;
        public string Name { get; set; }
        public int Age 
        {
            get {
                return this.age;
            }
            set {
                this.age = value;
                if (value%12==0)
                {
                    if (OnBenMingNian!= null)
                    {
                        OnBenMingNian();
                    }
                }
            }
        }

        public event Action OnBenMingNian;
        //public Action OnBenMingNian;
    }

    delegate void Say();
    delegate bool IsFirstBigFunc(object o1, object o2);
    delegate bool IsFirstBigFunc<T>(T t1,T t2);

}
