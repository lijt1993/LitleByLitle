using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fibonacci
{
    class Program
    {   
        static void Main(string[] args)
        {
            Console.WriteLine("请输入月数n");
            int n = int.Parse(Console.ReadLine());
            int[] intArray = new int[n];
            int i;
            intArray[0] = 0;
            intArray[1] = 1;


            for (i = 2; i < n; i++)
            {
                intArray[i] = intArray[i - 2] + intArray[i - 1];
                //Console.WriteLine(intArray[i]);
            }

            for (i = 0; i < n; i++)
            {
                Console.WriteLine(intArray[i]);
               
            }
            Console.ReadLine();

        }
    }
}
