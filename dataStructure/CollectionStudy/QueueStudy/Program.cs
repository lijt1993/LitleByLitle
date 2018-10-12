using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QueueStudy
{
    class Program
    {
        static void Main(string[] args)
        {
            Queue[] numQueue = new Queue[10];
            int[] nums = new int[] {91,46,85,15,92,35,31,22};
            int[] random = new Int32[99];

            //Display original list
            for (int i = 0; i < 10; i++)
            {
                numQueue[i] = new Queue();
            }
            RSort(numQueue,nums,DigitType.ones);
            BuildArray(numQueue,nums);
            Console.WriteLine();
            Console.WriteLine("First pass results:");
            DisplayArray(nums);

            //Second pass sort
            RSort(numQueue,nums,DigitType.tens);
            BuildArray(numQueue,nums);
            Console.WriteLine();
            Console.WriteLine("Second pass results:");
            DisplayArray(nums);

            Console.Read();

        }
        enum DigitType { ones = 1,tens = 10 }

        static void DisplayArray(int[] n)
        {
            for (int x = 0; x <= n.GetUpperBound(0); x++)
            {
                Console.Write(n[x]+" ");
            }
        }

        static void RSort(Queue[] que, int[] n, DigitType digit)
        {
            int snum;
            for (int x = 0; x <= n.GetUpperBound(0); x++)
            {
                if (digit == DigitType.ones)
                {
                    snum = n[x] % 10;
                }
                else
                {
                    snum = n[x] / 10;
                }
                que[snum].Enqueue(n[x]);
            }
        
        }

        static void BuildArray(Queue[] que, int[] n)
        {
            int y = 0;
            for (int x = 0; x <= 9; x++)
                while (que[x].Count > 0)
                {
                    n[y] = Int32.Parse(que[x].Dequeue().ToString());
                    y++;
                
                }
           }
       
    }
}
