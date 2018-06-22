using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace One_step_at_a_thousand_li
{
    class Program
    {
        static void Main(string[] args)
        {
            OneThousand ot = new OneThousand();
            Console.WriteLine(" “一步千里”之数组查找");
            const int MAXN = 10;
            int[] arr = {4,5,6,5,6,7,8,9,10,9 };
            //int[] arr = { 4, 5, 6, 5, 6, 7, 8, 9, 10, 9 };
            ot.PrintArray(arr,MAXN);

            for (int i = 0; i < MAXN; i++)
                Console.WriteLine("查找" + arr[i] + "  下标为" + ot.FindNumberInArray(arr, MAXN, arr[i]));

            //Console.WriteLine("查找" + 1 + "  下标为" + ot.FindNumberInArray(arr, MAXN, 1));
            //Console.WriteLine("查找" + 2 + "  下标为" + ot.FindNumberInArray(arr, MAXN, 2));
            //Console.WriteLine("查找" + -1 + "  下标为" + ot.FindNumberInArray(arr, MAXN, -1));

            

                Console.ReadLine();
        }
    }
    public class OneThousand
    { 
        //打印数组
        public void PrintArray(int[] a,int n)
        {
            for (int i = 0; i < n-1; i++)
                Console.Write(a[i]+" ");
        
        }
       //在数组中查找目标数
        public int FindNumberInArray(int[] arr,int n, int find_number)
        {
            int next_arrive_index = Math.Abs(find_number - arr[0]);
            while (next_arrive_index < n)
            {
                if (arr[next_arrive_index] == find_number)
                    return next_arrive_index;
                next_arrive_index = next_arrive_index + Math.Abs(find_number - arr[next_arrive_index]);
            }
            return -1;
        }
    }
}
