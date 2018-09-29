using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;

using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;

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

            #region serialize
            //Person person = new Person { Name = "long", Age = 18 };

            //BinaryFormatter binaryFormatter = new BinaryFormatter();
            //using (FileStream fs = new FileStream(@"C:\Users\banana\Desktop\test.data", FileMode.OpenOrCreate))
            //{
            //    binaryFormatter.Serialize(fs, person);
            //    Console.WriteLine("done");
            //}
            //using (FileStream fs = new FileStream(@"C:\Users\banana\Desktop\test.data", FileMode.OpenOrCreate))
            //{
            //    Person person = binaryFormatter.Deserialize(fs) as Person;
            //    Console.WriteLine(person.Name+" "+person.Age);
            //}

            //XmlSerializer xmlSerializer = new XmlSerializer(typeof(Person));

            //using (FileStream fs = new FileStream(@"C:\Users\banana\Desktop\test2.xml", FileMode.OpenOrCreate))
            //{
            //    xmlSerializer.Serialize(fs, person);
            //    Console.WriteLine("done");
            //} 
            #endregion

            #region xml读写
            //xml读取
            //XmlElement xmlElement = new XmlElement();
            //XmlDocument doc = new XmlDocument();
            //doc.Load(@"C:\Users\banana\Desktop\testXml.xml");
            //XmlNodeList students = doc.DocumentElement.ChildNodes;//Student节点集合
            //foreach (XmlNode stu in students)
            //{

            //    XmlElement element = (XmlElement)stu;
            //    string stuId = element.GetAttribute("StuID");
            //    XmlNode nameNode = element.SelectSingleNode("StuName");//获取Person节点的Name节点
            //    string name = nameNode.InnerText;
            //    Console.WriteLine(stuId + "," + name);

            //}

            //xml写入
            //Person[] persons = { new Person(1, "rupeng", 8), new Person(2, "baidu", 6) };
            //XmlDocument doc = new XmlDocument();
            //XmlElement ePersons = doc.CreateElement("Persons");
            //doc.AppendChild(ePersons);//添加根节点
            //foreach (Person person in persons)
            //{
            //    XmlElement ePerson = doc.CreateElement("Person");
            //    ePerson.SetAttribute("id", person.Id.ToString());
            //    XmlElement eName = doc.CreateElement("Name");
            //    eName.InnerText = person.Name;
            //    XmlElement eAge = doc.CreateElement("Age");
            //    eAge.InnerText = person.Age.ToString();
            //    ePerson.AppendChild(eName);
            //    ePerson.AppendChild(eAge);
            //    ePersons.AppendChild(ePerson);
            //}
            //doc.Save(@"C:\Users\banana\Desktop\testWriteXml.xml");
            //Console.WriteLine("done"); 
            #endregion

            //查看host和vm
            //XmlDocument doc = new XmlDocument();
            //doc.Load(@"C:\Users\banana\Desktop\CNET2SuperlabConfigurationMM_CDVR_5_For3.0.xml");

            //XmlNodeList hosts = doc.GetElementsByTagName("Host");

            //foreach (XmlNode host in hosts)
            //{
            //    XmlElement hostElement = (XmlElement)host;
            //    string hostName = hostElement.GetAttribute("name");
            //    string hostIpaddress = hostElement.GetAttribute("ipaddress");
            //    Console.WriteLine(hostName + "|" + hostIpaddress);
            //    foreach (XmlNode vm in hostElement.ChildNodes)
            //    {
            //        XmlElement vmElement = vm as XmlElement;
            //        List<string> vmInfo = new List<string>();
            //        string vmName = vmElement.GetAttribute("name");
            //        string vmIpaddress = vmElement.GetAttribute("ipaddress");
            //        string baseimage = vmElement.GetAttribute("baseimage");
            //        string memory = vmElement.GetAttribute("memory");
            //        string testquery = vmElement.GetAttribute("testquery");
            //        vmInfo.Add(vmName);
            //        vmInfo.Add(vmIpaddress);
            //        vmInfo.Add(baseimage);
            //        vmInfo.Add(memory);
            //        vmInfo.Add(testquery);
            //        //Console.WriteLine("    "+string.Join("|",vmInfo));
            //    }
            //}

            //新增host节点
            //XmlElement newHostElement = doc.CreateElement("Host");
            //XmlElement templateHost = (XmlElement)hosts.Item(0)
            //XmlElement newHostElement = (XmlElement)hosts.Item(0).CloneNode(false);
            //newHostElement.SetAttribute("name", "MRBJ-VHOST-132");
            //newHostElement.SetAttribute("ipaddress", "nice");
            //doc.DocumentElement.AppendChild(newHostElement);


            //host排序。排序比较困难。。
            //XmlElement = hosts.Cast<XmlElement>().OrderBy<XmlElement,string>(x=>x.GetAttribute("name"));
            //doc.InsertAfter()

            //修改host节点
            //List<XmlElement> hostNodes = new List<XmlElement>();
            //foreach (XmlNode host in hosts)
            //{
            //    hostNodes.Add((XmlElement)host);
            //}

            //XmlElement hostNode = hostNodes.Where(x => x.GetAttribute("name")== "MRBJ-VHOST-133").Single<XmlElement>();
            //hostNode.SetAttribute("ipaddress","cool");


            //保存
            //doc.Save(@"C:\Users\banana\Desktop\CNET2SuperlabConfigurationMM_CDVR_5_For3.0.xml");

            //修改config
            XmlDocument doc = new XmlDocument();
            doc.Load(@"C:\Users\banana\Desktop\TemplateConfigS3_0_SCCM.xml");
            XmlNodeList adds = doc.GetElementsByTagName("add");
            foreach (XmlNode add in adds)
            {
                XmlElement addElement = (XmlElement)add;
                string keyName = addElement.GetAttribute("key");
                //Console.WriteLine(keyName);
                if (keyName== "Lab")
                {
                    addElement.SetAttribute("value", "BJGP0021");
                }
            }
            doc.Save(@"C:\Users\banana\Desktop\TemplateConfigS3_0_SCCM_new.xml");

            Console.WriteLine("done");
            Console.ReadKey();
        }

    }
    //[Serializable]
    //public class Person
    //{
    //    public string Name { get; set; }
    //    public int Age { get; set; }
    //}

    class Person
    {
        public Person(int id, string name, int age)
        {
            this.Id = id;
            this.Name = name;
            this.Age = age;
        }
        public int Id { set; get; }
        public string Name { set; get; }
        public int Age { set; get; }
    }
   

}
