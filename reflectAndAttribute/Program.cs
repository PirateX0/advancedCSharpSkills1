using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using System.ComponentModel;

namespace reflectAndAttribute
{
    class Program
    {
        static void Main(string[] args)
        {
            #region type成员
            //Children c = new Children();
            //c.TestThis();

            //Type t1 = typeof(Person);
            //Type t2 = new Person().GetType();
            //Type t3 = Type.GetType("reflectAndAttribute.Person");
            //Console.WriteLine(t1.ToString()+t2+t3);

            //object o= Activator.CreateInstance(t1);
            //Console.WriteLine(o.ToString());

            //Console.WriteLine(typeof(Children).BaseType);
            //Console.WriteLine(typeof(Children).IsClass);
            //Console.WriteLine(typeof(Children).Name);

            //Type[] types = { };
            //ConstructorInfo c = typeof(Person).GetConstructor(new Type[]{typeof(int)});
            //Console.WriteLine(c);

            //MethodInfo m = typeof(Person).GetMethod("Hello",new Type[1]{typeof(string)});
            //Console.WriteLine(m);

            //PropertyInfo p = typeof(Person).GetProperty("Age");
            //Console.WriteLine(p);

            //MethodInfo[] methods = typeof(Person).GetMethods();
            //foreach (var item in methods)
            //{
            //    Console.WriteLine(item);
            //} 
            #endregion

            #region 利用反射显示属性和深、浅拷贝
            //Type t = typeof(Person);
            ////object o = Activator.CreateInstance(t);
            //object o = t.GetConstructor(new Type[0]).Invoke(new object[0]);
            //PropertyInfo name = t.GetProperty("Name");
            //name.SetValue(o,"dalong");
            //PropertyInfo age = t.GetProperty("Age");
            //age.SetValue(o,18);
            //PropertyInfo child = t.GetProperty("Child");
            //child.SetValue(o, new Children { Age=1,Name="a gan"});

            //MethodInfo method=t.GetMethod("SayHi",new Type[0]);
            //MethodInfo method2 = t.GetMethod("SayHi", new Type[]{typeof(string)});
            //method.Invoke(o,new object[0]);
            //method2.Invoke(o,new object[]{"jie"});

            //ShowObjectProperties(o);

            // Person oP = o as Person;

            //Person p = CloneObjectShallowly(o) as Person;
            //ShowObjectProperties(p);
            //Console.WriteLine(object.ReferenceEquals(p,o));
            //Console.WriteLine(object.ReferenceEquals(oP.Child, p.Child));


            //Person p2 = CloneObjectDeeply(o) as Person;
            //ShowObjectProperties(p);
            //Console.WriteLine(object.ReferenceEquals(p,o));
            // Console.WriteLine(object.ReferenceEquals(oP.Child,p2.Child));
            // ShowObjectProperties(p2.Child); 
            #endregion

            #region 内置attribute和自定义attribute
            //Person p = new Person { Name = "666", Age = 10, Child = new Children() { Name = "haha", Age = 99 } };
            //ShowObjectProperties(p);

            ShowCodeAuthor(typeof(Person)); 
            #endregion

            Console.ReadKey();
        }

        [Obsolete]
        public static void ShowObjectProperties(object o)
        {
            PropertyInfo[] properties = o.GetType().GetProperties();
            foreach (var property in properties)
            {
                if (property.CanRead)
                {
                    Console.WriteLine(GetDisplayName(property) + " = " + property.GetValue(o));
                }
            }
        }

        public static string GetDisplayName(PropertyInfo p)
        {
            DisplayNameAttribute d = p.GetCustomAttribute(typeof(DisplayNameAttribute)) as DisplayNameAttribute;
            if (d != null)
            {
                return d.DisplayName;
            }
            else
            {
                return p.Name;
            }
        }

        public static void ShowCodeAuthor(Type t)
        {
            AuthorAttribute d = t.GetCustomAttribute(typeof(AuthorAttribute)) as AuthorAttribute;
            if (d != null)
            {
                Console.WriteLine(d.AuthorName);
            }
            else
            {
                Console.WriteLine("unknown");
            }
        }

        public static object CloneObjectShallowly(object o)
        {
            Type t = o.GetType();
            object newObj = Activator.CreateInstance(t);
            PropertyInfo[] properties = o.GetType().GetProperties();
            foreach (var property in properties)
            {
                if (property.CanRead && property.CanWrite)
                {
                    object oldValue = property.GetValue(o);
                    property.SetValue(newObj, oldValue);
                }
            }
            return newObj;
        }

        public static object CloneObjectDeeply(object o)
        {
            Type t = o.GetType();
            object newObj = Activator.CreateInstance(t);
            PropertyInfo[] properties = o.GetType().GetProperties();
            foreach (var property in properties)
            {
                if (property.CanRead && property.CanWrite)
                {
                    if (property.PropertyType.IsValueType || property.PropertyType == typeof(string))
                    {
                        object oldValue = property.GetValue(o);
                        property.SetValue(newObj, oldValue);
                    }
                    else
                    {
                        object newValueObject = Activator.CreateInstance(property.PropertyType);
                        object oldValueObject = property.GetValue(o);
                        if (oldValueObject != null)
                        {
                            newValueObject = CloneObjectDeeply(oldValueObject);
                            property.SetValue(newObj, newValueObject);
                        }
                    }
                }
            }
            return newObj;
        }
    }

    [AttributeUsage(AttributeTargets.All, Inherited = false, AllowMultiple = true)]
    sealed class AuthorAttribute : Attribute
    {
        // See the attribute guidelines at 
        //  http://go.microsoft.com/fwlink/?LinkId=85236
        readonly string authorName;

        // This is a positional argument
        public AuthorAttribute(string authorName)
        {
            this.authorName = authorName;
        }

        public string AuthorName
        {
            get { return authorName; }
        }
    }

    [Author("long")]
    class Person
    {
        public int Age { get; set; }

        [DisplayName("xing ming")]
        public string Name { get; set; }

        public Children Child { get; set; }

        public Person(int i)
        {

        }

        public Person()
        {

        }

        public override string ToString()
        {
            return "i am person class";
        }

        public void Hello()
        {
            this.TestThis();
        }

        public void Hello(string str)
        {
            Console.WriteLine(str);
        }

        public virtual void TestThis()
        {
            Console.WriteLine("parent");
        }

        public void SayHi()
        {
            Console.WriteLine("hi, My name is " + this.Name + ", I'm " + this.Age + " years old:)");
        }

        public void SayHi(string str)
        {
            Console.WriteLine("hi " + str + ", My name is " + this.Name + ", I'm " + this.Age + " years old:)");
        }
    }

    class Children : Person
    {
        public override void TestThis()
        {
            Console.WriteLine("children");
        }

        public override string ToString()
        {
            return "i am children class";
        }
    }
}
