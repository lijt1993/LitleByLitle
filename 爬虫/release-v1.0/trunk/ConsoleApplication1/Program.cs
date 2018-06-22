using EasySpider;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            //Spider sp = new Spider();
            Spider.Get("news.sina.com.cn");
            //sp.GetHashCode(
        }
    }
}
