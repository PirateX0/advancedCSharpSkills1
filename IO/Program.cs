using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IO
{
    class Program
    {
        static void Main(string[] args)
        {
            #region file读写文件
            //string s = File.ReadAllText(@"C:\Users\banana\Desktop\test.txt", Encoding.UTF8);
            //Console.WriteLine(s);
            //File.WriteAllText(@"C:\Users\banana\Desktop\test.txt", "ssssss");
            //File.AppendAllText(@"C:\Users\banana\Desktop\test.txt", "00000");
            //Console.WriteLine("done"); 
            #endregion


            #region filestream读取和写入
            //FileStream fs = new FileStream(@"C:\Users\banana\Desktop\test2.txt", FileMode.Create);
            //byte[] bytes1 = Encoding.Default.GetBytes("hello\r\n");
            ////任何数据都是以byte为单位写入的。GetBytes获得字符串的byte表示形式
            //fs.Write(bytes1, 0, bytes1.Length);

            //byte[] bytes2 = Encoding.Default.GetBytes("www.rupeng.com");
            //fs.Write(bytes2, 0, bytes2.Length);//在上一个Write的结尾继续写入
            //fs.Close();//一定要用完了关闭

            //Console.WriteLine("done");

            //using (FileStream fs = new FileStream(@"C:\Users\banana\Desktop\test.txt", FileMode.Open))
            //{

            //    byte[] bytes = new byte[4];
            //    //fs.Read(bytes, 0, bytes.Length);//每次读取4个字节，下次Read的时候再读取最多4个byte
            //    //返回值为真正读取的字节数
            //    int len;

            //    //len = fs.Read(bytes, 0, bytes.Length);
            //    //Console.WriteLine(len);
            //    //len = fs.Read(bytes, 0, bytes.Length);
            //    //Console.WriteLine(len);
            //    //len = fs.Read(bytes, 0, bytes.Length);
            //    //Console.WriteLine(len);


            //    //判断是否已经读到了最后
            //    while ((len = fs.Read(bytes, 0, bytes.Length)) > 0)
            //    {
            //        //Console.WriteLine(len);
            //        //把byte数组转化为字符串
            //        //string s = Encoding.Default.GetString(bytes);
            //        string s = Encoding.Default.GetString(bytes, 0, len);
            //        Console.WriteLine(s);
            //    }

            //} 
            #endregion

            #region streamwiter,streamreader读写
            //using (Stream outStream =
            //    new FileStream(@"C:\Users\banana\Desktop\test.txt", FileMode.Append))
            //using (StreamWriter sw =
            //    new StreamWriter(outStream, Encoding.Default))
            //{
            //    sw.Write("hi");
            //    sw.WriteLine("hehe");
            //    sw.WriteLine("1111");
            //}

            //Console.WriteLine("done");

            //using (Stream inStream = 
            //    new FileStream(@"C:\Users\banana\Desktop\test.txt",FileMode.Open))
            //using (StreamReader reader =
            //    new StreamReader(inStream, Encoding.Default))
            //{
            //    /*
            //    string s = reader.ReadToEnd();
            //    Console.Write(s);*/
            //    /*
            //    string s1 = reader.ReadLine();
            //    Console.WriteLine(s1);

            //    string s2 = reader.ReadLine();
            //    Console.WriteLine(s2);
            //        */
            //    string line;
            //    while ((line = reader.ReadLine()) != null)
            //    {
            //        Console.WriteLine(line);
            //    }
            //} 
            #endregion

            //合并图片
            //通过图片大小可得知是否成功，新图片大小=老图片1大小+老图片2大小
            //using (Stream streamReader = new FileStream(@"F:\图片\小新.jpg", FileMode.Open))
            //using (Stream streamReader2 = new FileStream(@"F:\图片\小和尚.jpeg", FileMode.Open))
            //using (Stream streamWriter = new FileStream(@"F:\图片\小小新.jpg", FileMode.Create))
            //{
            //    byte[] bytes = new byte[1024 * 1024];//1M的缓存
            //    int length;
            //    while ((length = streamReader.Read(bytes, 0, bytes.Length)) != 0)
            //    {
            //        streamWriter.Write(bytes, 0, length);
            //    }
            //    //再次写入需要设置偏移量吗？//不需要，参考合并文本。会自动往后写。
            //    while ((length = streamReader2.Read(bytes, 0, bytes.Length)) != 0)
            //    {
            //        streamWriter.Write(bytes, 0, length);
            //    }
            //}

            //合并文本
            //using (Stream streamReader=new FileStream(@"F:\图片\情书上.txt",FileMode.Open))
            //using(StreamReader reader=new StreamReader(streamReader,Encoding.Default))
            //using (Stream streamReader2 = new FileStream(@"F:\图片\情书下.txt", FileMode.Open))
            //using (StreamReader reader2 = new StreamReader(streamReader2,Encoding.Default))
            //using(Stream streamWriter=new FileStream(@"F:\图片\情书.txt",FileMode.Create))
            //using (StreamWriter writer = new StreamWriter(streamWriter, Encoding.Default))
            //{
            //    string s;
            //    while ((s= reader.ReadLine())!=null)
            //    {
            //        writer.WriteLine(s);
            //    }
            //    while ((s=reader2.ReadLine())!=null)
            //    {
            //        writer.WriteLine(s);
            //    }
            //}

            

            Console.ReadKey();
        }
    }
}
