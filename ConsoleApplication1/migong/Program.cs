using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace migong
{
    class Program
    {
        //定义二维数组
        int[,] maze = new int[7, 7] 
            {
             {2,2,2,2,2,2,2},
             {2,0,0,0,0,0,2},
             {2,0,2,0,2,0,2},
             {2,0,0,2,0,2,2},
             {2,2,0,2,0,2,2},
             {2,0,0,0,0,0,2},
             {2,2,2,2,2,2,2}
             };
        int startI = 1, startJ = 1;
        int endI = 5, endJ = 5;
        int success = 0;

        static void Main(string[] args)
        {
           Program p =new Program();

            int i, j;
            Console.WriteLine("显示迷宫：\n");


            for (i = 0; i < 7; i++)
            {
                for (j = 0; j < 7; j++)
                {
                    if (p.maze[i, j] == 2)
                        Console.Write("#");
                    else
                        Console.Write(" ");
                }
                Console.WriteLine();
            
            }


            if (p.visit(p.startI, p.startJ) == 0)
                Console.WriteLine("\n没有找到出口!\n");
            else
            {
                Console.WriteLine("\n显示路径：\n");
                for (i = 0; i < 7; i++)
                {
                    for (j = 0; j < 7; j++)
                    {
                        if (p.maze[i,j] == 2)
                            Console.Write("#");
                        else if (p.maze[i,j] == 1)
                            Console.Write("1");
                        else
                            Console.Write(" ");
                    }
                    Console.WriteLine();
                }
            }

            Console.ReadLine();
          
        }


        int visit(int i, int j)
        {
            maze[i, j] = 1;
            if (i == endI && j == endJ)
                success = 1;

            if (success != 1 && maze[i, j + 1] == 0)
                visit(i, j + 1);
            if (success != 1 && maze[i + 1, j] == 0)
                visit(i + 1, j);
            if (success != 1 && maze[i, j - 1] == 0)
                visit(i, j - 1);
            if (success != 1 && maze[i - 1, j] == 0)
                visit(i - 1, j);
           
            
            if (success != 1)
                maze[i,j] = 0;
            
            return success;
        }
  
    
    
    
    }
}
