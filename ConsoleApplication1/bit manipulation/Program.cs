using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bit_manipulation
{
    class Program
    {/*    符号      描述           运算规则  
        
      *     &         与         两个位都为1时，结果才为1
      *     
      *     |         或         两个位都为0时，结果才为0
      *     
      *     ^        异或        两个位相同为0，相异为1
      *     
      *     ~        取反         0变1，1变0
      *     
      *     <<       左移        各二进位全部左移若干位，高位丢弃，低位补0
      *     
      *     >>       右移        各二进位全部右移若干位，对无符号数，高位补0，有符号数，各
      *                          编译器处理方法不一样，有的补符号位（算术右移），
      *                          有的补0（逻辑右移）
      */
        
        static void Main(string[] args)
        {
     
            

            //#region 常用位操作小技巧
            //// 1 判断奇偶
            //Console.WriteLine("1.判断奇偶");
            //for (int i = 0; i < 100; i++)
            //{
            //    if ((i & 1) == 0)
            //        Console.WriteLine(i);
       
            //}


            bit_operation bo = new bit_operation();
            bo.Swap(3, 8);
            bo.MissNumber(); 
            bo.FindTwoNotRepeatNumberInArray();
            bo.FindNumber();


            //#endregion
            //为毛不加该代码，控制台总是一闪而过
                Console.ReadLine();
        }
    }

    public class bit_operation
    {
        
        #region 交换两数

        //一般写法

        public void Swap1(int a, int b)
        {
            if (a != b)
            {
                int c = a;
                a = b;
                b = c;
            }
        }

        //可以用位操作来实现交换两数而不用第三方变量
        public void Swap(int a, int b)
        {

            Console.WriteLine("1.交换两个数据");
            Console.WriteLine(a);
            Console.WriteLine(b);
            if (a != b)
            {
                a ^= b;//a=(a^b)  3 ,8  11 ^1000 = 1011
                b ^= a;//b=(b^a) = b^a^b = b^b^a = a; 1011^1000 = 11 3
                a ^= b;//a=(a^b) = a^b^a = b 疑惑？

            }
            Console.WriteLine(a);
            Console.WriteLine(b);
        }
       
        #endregion

        #region 缺失的数字

        public void MissNumber()
        {
            Console.WriteLine();
            Console.WriteLine("2.缺失的数字");

            const int MAXN = 15;
           // int[MAXN] a = {1, 347, 6, 9, 13, 65, 889, 712, 889, 347, 1, 9, 65, 13, 712}; 
            int[] a = new int[MAXN] { 1, 347, 6, 9, 13, 65, 889, 712, 889, 347, 1, 9, 65, 13, 712 };
            int lostNum = 0;
            for (int i = 0; i < MAXN; i++)
                lostNum ^= a[i];

            Console.WriteLine("缺失的数字为："+lostNum);
        }
 
        #endregion

        #region 不重复出现的两个数字(在一个数组中)
        public void FindTwoNotRepeatNumberInArray()
        {
            Console.WriteLine();
            Console.WriteLine("3.找到不重复出现的两个数");
           
            const int n = 10;
            int[] a = new int[10] { 1, 2, 3, 4, 1, 2, 3, 4, 0, 5 };
            Console.WriteLine("数组为");
            for (int ii = 0; ii < n; ii++)
                Console.WriteLine(a[ii]);
            //计算这两个数的异或结果
            int i, j, temp;
            temp = 0;
            for (i = 0; i < n; i++)
                temp ^= a[i];
            //找到第一个为1的位
            for (j = 0; j < sizeof(int) * 8; j++)
                if (((temp >> j) & 1) == 1)
                    break;
            //第j位为1，说明这两个数字在第j位上是不相同的
            //由此分组既可
           int pN1 = 0, pN2 = 0 ;
            for (i = 0; i < n; i++)
                if (((a[i] >> j) & 1) == 0)
                    pN1 ^= a[i];
                else
                    pN2 ^= a[i];



            Console.WriteLine("不重复出现的两个数分别是"+pN1 +" 和"+pN2);
        }
        #endregion

        #region 数组A中，除了某一个数字x之外，其他数字都出现了三次，而x出现了一次，请给出最快的方法找到x

        public void FindNumber()
        { 
            int [] bits = new int[32];
            const int n = 10;
            int [] a = new int[n]{2,3,1,2,3,4,1,2,3,1};
            int i, j;
            // 累加数组中所有数字的二进制位
            //Array.Clear(bits, 0, 32 * sizeof(int)); 
            for(i = 0;i < n;i++)
                for(j = 0;j < 32;j++)
                    bits[j] += ((a[i]>>j)&1);
 
            //如果某位上的结果不能被整除，则肯定目标数字在这一位上
            int result = 0;
            for (j = 0; j < 32; j++)
                if (bits[j] % 3 != 0)
                    result += (1 << j);

            Console.WriteLine(result);

        
        }
        #endregion

    }
  

}
