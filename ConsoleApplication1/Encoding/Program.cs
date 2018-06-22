using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Encode
{
    class ByteToString
    {
        static void Main(string[] args)
        {
            String s = "This is a test data. 这是一个测试数据。";
            //字符串换到字节数组
            //UTF8编码
            Byte[] utf8 = StrToByte(s, Encoding.UTF8);
            //GB2312编码
            Byte[] gb2312 = StrToByte(s,Encoding.GetEncoding("GB2312"));
            Console.WriteLine("同一段字符串用UTF8编码后的长度："+utf8.Length);
            Console.WriteLine("同一段字符串用GB2312编码后的长度："+gb2312.Length);
            
            //转换回字符串
            Console.WriteLine("UTF8编码："+ByteToStr(utf8,Encoding.UTF8));
            Console.WriteLine("GB2312编码："
                +ByteToStr(gb2312,Encoding.GetEncoding("GB2312")));
            Console.Read();
        }

        //把字符串转换为字节数组
        static Byte[] StrToByte(String s, Encoding encoding)
        {
            return encoding.GetBytes(s);
        }
        //把字节数组转换为字符串
        static String ByteToStr(Byte[] b, Encoding encoding)
        {
            return encoding.GetString(b); 
        }
    }
}
