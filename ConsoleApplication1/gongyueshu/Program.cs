using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gongyueshu
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("请输入两个数");
             int m = int.Parse(Console.ReadLine());
             int n = int.Parse(Console.ReadLine());

             int s = m * n;
             while (n != 0)
             {
                 int r = m % n;
                 m = n;
                 n = r;
             }

             Console.WriteLine("最大公约数是"+m);
             Console.WriteLine("最小公倍数是"+s/m);
             Console.ReadLine();
        }
    }
}
