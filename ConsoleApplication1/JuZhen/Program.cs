using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JuZhen
{
    class Program
    {
        static void Main(string[] args)
        {
            int[,] arr1 = 
            { 
            {1,2,3,4},
            {5,6,7,8},
            {9,10,11,12}
            };
            int[] arr2 = new int[12];
            int row, column, i;
            Console.WriteLine("原二维矩阵");
            for (row = 0; row < 3; row++)
            {
                for (column = 0; column < 4; column++)
                {
                    Console.Write(arr1[row,column]+" ");
                }
                Console.WriteLine();
            }


            Console.WriteLine("以列为主  ");
            for (row = 0; row < 3; row++)
            {
                for (column = 0; column < 4; column++)
                {
                    i = column + row * 4;
                    arr2[i] = arr1[row, column];
                }
            
            }
            for (i = 0; i < 12; i++)
            {
                Console.Write(arr2[i]);
            }

            Console.WriteLine();

            Console.WriteLine("以行为主");
            for (row = 0; row < 3; row++)
            {
                
                for (column = 0; column < 4; column++)
                { 
                    i= row + column*3;
                    arr2[i] = arr1[row, column];
                }
            
            }
            for (i = 0; i < 12; i++)
            {
                Console.Write(arr2[i]);
            }
            Console.ReadLine();


        }
    }
}
