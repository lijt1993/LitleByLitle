using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YangHuiSquare
{
    class Program
    {
        
        static void Main(string[] args)
        {
            #region 杨辉三角形
            int x, y;
            int [,] triangle = new int[6,6];
            for (x = 0; x <= 5; x++)
            {
                for (y = 0; y <= x; y++)
                {
                    if (x == y || y == 0)


                        triangle[x, y] = 1;

                    else
                        triangle[x, y] = triangle[x - 1, y - 1] + triangle[x - 1, y];

                    Console.Write(triangle[x,y]+" ");

                }
                Console.WriteLine();

            }
            Console.ReadLine();
            #endregion

        }

     
    }
}
