using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeNeiZhiTa
{
    class Program
    {
   

            static void Main(string[] args)
            {
                Program p = new Program();
                int n;
                Console.WriteLine("请输入盘数");
               // ConsoleKeyInfo i = Console.ReadKey(true);
                 n = int.Parse( Console.ReadLine());

                p.hanoi(n, "A", "B", "C");

                Console.ReadLine();

            }
            void hanoi(int n, string A, string B, string C)
            {

                if (n == 1)
                {
                    Program p = new Program();
                    Console.WriteLine("Move sheet" + n + "from" + A + "to" + C);
                }
                else
                {
                    Program p = new Program();
                    hanoi(n - 1, A, C, B);
                    Console.WriteLine("Move sheet" + n + "from" + A + "to" +C);
                    hanoi(n - 1, B, A, C);
                }

            }

            #region
            //        #include <stdio.h>

            //void hanoi(int n, int A, int B, int C)
            //{
            //    if(n == 1)
            //        printf("Move sheet %d from %c to %c\n", n, A, C);
            //    else
            //    {
            //        hanoi(n-1, A, C, B);
            //        printf("Move sheet %d from %c to %c\n", n, A, C);
            //        hanoi(n-1, B, A, C);
            //    }
            //}

            //int main(void)
            //{
            //    int n;
            //    printf("请输入盘数: \n");
            //    scanf("%d", &n);
            //    hanoi(n, 'A', 'B', 'C');
            //    return 0;
            //}
            #endregion








        }
  
}
