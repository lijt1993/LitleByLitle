using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScopeValue
{
    class ScopeValue
    {
        static int k = 44;       //定义一个变量k
        public static void Main()
        {
            int k = 88;

            for (int i = 0; i < 10; i++) { Console.WriteLine(i); }
            for (int i = 0; i < 20; i++) { Console.WriteLine(i); }

            Console.WriteLine(k);
            Console.WriteLine(ScopeValue.k);
            Console.Read();
        
        }
     
    }
}
