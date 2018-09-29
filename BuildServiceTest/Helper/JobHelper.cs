using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildServiceTest.Helper
{
    class JobHelper
    {
        public void GenerateSCCM()
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(@"C:\Users\banana\Desktop\TemplateConfigS3_0_SCCM.xml");
            XmlNodeList adds = doc.GetElementsByTagName("add");
            foreach (XmlNode add in adds)
            {
                XmlElement addElement = (XmlElement)add;
                string keyName = addElement.GetAttribute("key");
                //Console.WriteLine(keyName);
                if (keyName == "Lab")
                {
                    addElement.SetAttribute("value", "BJGP0021");
                }
            }
            doc.Save(@"C:\Users\banana\Desktop\TemplateConfigS3_0_SCCM_new.xml");
        }

        public BuildTask GetBuildTask()
        {

        }
    }
}
