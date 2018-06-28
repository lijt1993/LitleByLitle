using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortTest
{
    class Program
    {
        static void Main(string[] args)
        {
            Carry nums = new Carry(10);
            Random rnd = new Random();
            for (int i = 0; i < 10; i++)
            {
                nums.insert(rnd.Next(0,100));
            }

            Console.WriteLine("before sorting");
            nums.DisplayElements();
            Console.WriteLine("during sorting");
            //nums.BubbleSort();
            nums.selectionSort();
            Console.WriteLine("after sorting");
            nums.DisplayElements();
            Console.ReadKey();
        }


     
    }
}
