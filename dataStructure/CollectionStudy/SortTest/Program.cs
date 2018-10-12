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
            //Carry nums = new Carry(10);
            //Random rnd = new Random();
            //for (int i = 0; i < 10; i++)
            //{
            //    nums.insert(rnd.Next(0,100));
            //}

            //Console.WriteLine("before sorting");
            //nums.DisplayElements();
            //Console.WriteLine("during sorting");
            ////nums.BubbleSort();
            ////nums.selectionSort();
            //nums.InsertSort();
            //Console.WriteLine("after sorting");
            //nums.DisplayElements();
            //Console.ReadKey();


            #region 比较三个排序的效率

           
            int arraysize = 50000;
            Carry sortarray = new Carry(arraysize);

            Random rnd = new Random();





            //Timing sorttime3 = new Timing();
            //for (int i = 0; i < arraysize; i++)
            //{
            //    sortarray.insert(rnd.Next(0, 1000));

            //}
            //sorttime3.startTime();
            //sortarray.BubbleSort();
            //sorttime3.stopTime();
            //Console.WriteLine("Time of the bubblesort: " + sorttime3.Result().TotalMilliseconds);
            //sortarray.Clear();



            //Timing sorttime2 = new Timing();
            //for (int i = 0; i < arraysize; i++)
            //{
            //    sortarray.insert(rnd.Next(0, 1000));

            //}
            //sorttime2.startTime();
            //sortarray.selectionSort();
            //sorttime2.stopTime();
            //Console.WriteLine("Time of the selectsort: " + sorttime2.Result().TotalMilliseconds);
            ////sortarray.Clear();


            Timing sorttime1 = new Timing();
            for (int i = 0; i < arraysize; i++)
            {
                sortarray.insert(rnd.Next(0, 1000));

            }
            sorttime1.startTime();
            sortarray.InsertSort();
            sorttime1.stopTime();
            Console.WriteLine("Time of the insertsort: " + sorttime1.Result().TotalMilliseconds);

          

            Console.Read();




    


            #endregion
        }


     
    }
}
