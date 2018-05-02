using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace allKindsOfCSharpKnowledge
{
    class Program
    {
        static void Main(string[] args)
        {


            #region 索引器
            //infoHelper info = new infoHelper();
            //string s=info[1];
            //Console.WriteLine(s);

            //info[2] = "test index";
            //string s2 = info["long"];
            //Console.WriteLine(s2);
            //info["long"] = "god"; 
            #endregion

            #region 扩展方法
            //Console.WriteLine(LongExtensionFunction.IsBlank(null)); 

            //Console.WriteLine("long".IsBlank());

            //Console.WriteLine(string.IsNullOrEmpty("          ")); 
            #endregion

            #region 值类型和引用类型赋值
            //Person p = new Person();
            //p.Name = "long";
            //Person p2 = p;
            //Console.WriteLine(p2.Name);
            //p.Name = "jie";
            //Console.WriteLine(p2.Name);

            //Person p3 = new Person();
            //p3.Name = p.Name;
            //Console.WriteLine(p3.Name);
            //p.Name = "long";
            //Console.WriteLine(p3.Name);

            //Cat p = new Cat();
            //p.Name = "long";
            //Cat p2 = p;
            //Console.WriteLine(p2.Name);
            //p.Name = "jie";
            //Console.WriteLine(p2.Name);

            //int[] nums = { 3, 5, 6};
            //Test(nums);
            //Console.WriteLine(nums[1]);

            #endregion

            #region 深拷贝和浅拷贝
            //Dog d = new Dog();
            //d.Name = "wangcai";

            ////浅拷贝
            //Person p = new Person();
            //p.Name = "dalong";
            //p.Dog = d;
            //Person p2 = new Person();
            //p2.Name = p.Name;
            //p2.Dog = p.Dog;

            //d.Name = "ruhua";
            //Console.WriteLine(p2.Dog.Name);

            ////深拷贝
            //Person p3 = new Person();
            //p3.Name = p.Name;
            //Dog d2 = new Dog();
            //d2.Name = p.Dog.Name;
            //p3.Dog = d2;

            //d.Name = "bajie";
            //Console.WriteLine(p3.Dog.Name); 
            #endregion


            #region 装箱和拆箱
            //int i = 666;
            //object intObject = i;
            //long i2 = Convert.ToInt64(intObject);
            //Console.WriteLine(i2); 
            #endregion

            #region 相等
            //int i = 666;
            //long j = 666;
            //Console.WriteLine(i.Equals(j));//false
            //Console.WriteLine(i == j);//true

            //String s1 = "abc";
            //string s2 = s1;
            //string s3 = new String(new char[] { 'a', 'b', 'c' });
            //Console.WriteLine(s1==s2);
            //Console.WriteLine(s1 == s3);
            //Console.WriteLine(s1.Equals(s2));
            //Console.WriteLine(s1.Equals(s3));
            //Console.WriteLine(object.ReferenceEquals(s1,s2));
            //Console.WriteLine(object.ReferenceEquals(s1, s3));//false 

            #endregion

            #region 字符串缓存池
            //string s1 = "rupeng";
            //string s2 = "rupeng";
            //string s3 = "ru" + "peng";
            //string s4 = new string(s1.ToCharArray());
            //string s5 = new string(new char[] { 'r', 'u', 'p', 'e', 'n', 'g' });
            //Console.WriteLine(Object.ReferenceEquals(s1, s2));
            //Console.WriteLine(Object.ReferenceEquals(s1, s3));
            //Console.WriteLine(Object.ReferenceEquals(s1, s4));
            //Console.WriteLine(Object.ReferenceEquals(s1, s5));
            //Console.WriteLine(Object.ReferenceEquals(s4, s5)); 
            #endregion

            #region ref和out
            //int i = 5;
            //int j = 6;
            //Console.WriteLine("before swap: i=" + i + ",j=" + j);
            //Swap(i,j);
            //Console.WriteLine("after swap: i=" + i + ",j=" + j);
            //Swap(ref i,ref j);
            //Console.WriteLine("after ref swap: i="+i+",j="+j);


            //string str = "666";
            //if (int.TryParse(str,out i))
            //{
            //    Console.WriteLine(i);
            //}
            //else
            //{
            //    Console.WriteLine("illegal");
            //}

            //int i1, i2, i3;
            //Multi_Config(out i1,out i2,out i3);
            //Console.WriteLine("i1="+i1+",i2="+i2+",i3="+i3); 
            #endregion


            Console.ReadKey();
        }
        static void Test(int[] nums)
        {
            nums[1] = 666;
        }
        static void Swap(ref int i,ref int j)
        {
            int temp = i;
            i = j;
            j = temp;
        }

        static void Swap( int i,  int j)
        {
            int temp = i;
            i = j;
            j = temp;
        }

        //static void Swap(out int i,out int j)
        //{
        //    int temp = i;
        //    i = j;
        //    j = temp;
        //}

        static void Multi_Config(out int i, out int j, out int k)
        {
            i = 666;
            j=777;
            k=888;
        }
    }
    class Person
    {
        public string Name { get; set; }
        public Dog Dog { get; set; }

    }

    class Dog
    {
        public string Name { get; set; }
    }

    struct Cat
    {
        public string Name { get; set; }
    }
}
