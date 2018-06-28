using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Collections;

namespace timeTest
{
    class Program
    {
        static void Main(string[] args)
        {
            #region test
            //int[] nums = new int[100000];
            //BuildArray(nums);
            //Timing tobj = new Timing();
            //tobj.startTime();
            //DisplayNums(nums);
            //tobj.stopTime();
            //Console.WriteLine("TIME(.NET)"+tobj.Result());
            int total = sumNumbers(1,2,300);
           // Console.WriteLine(total);
            ArrayList aa = new ArrayList();
            aa.Add(1);
            aa.Add(2);
            aa.Add(3);
            aa.Add(1);
            aa.Add("没房子");
            aa.Add(1);
            aa.Add(2);
            aa.Add(3);
            aa.Add(1);
            
            Console.WriteLine(aa.Capacity +"  "+aa.Count);
            Console.Read();
            #endregion

            //#region  比较Collection与ArrayList的性能

            //Collection coenums = new Collection();

            //Array i = new int [100];

            //#endregion

        }
        static void BuildArray(int[] arr)
        {
            for (int i = 0; i <= 99999; i++)
            {
                arr[i] = i;
            }
        }

        //static void BuildCollection

        static void DisplayNums(int[] arr)
        {
            for (int i = 0; i <= arr.GetUpperBound(0); i++)
            {
                Console
                    .Write(arr[i] + "");
            }
        }


        //参数数组
        static int sumNumbers(params int[] nums)
        {
            int sum = 0;
            for (int i = 0; i <= nums.GetUpperBound(0); i++)
            {
                sum += nums[i];
            }
            return sum;
        }

    }
}
