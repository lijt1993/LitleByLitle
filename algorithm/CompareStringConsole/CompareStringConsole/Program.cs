using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
namespace CompareStringConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            Program program = new Program();
            string LongString = "ABCDEFGHI";
            string shortString = "ABCDEZ";

            #region  借用一下
            string[] number = new string[] { "1" ,"465"};
            //int a = number[0].Length;
            number = number.Where(m => m.Length == 1).ToArray();
            Console.WriteLine(number[0].Length);
        CollectionBase
               ArrayList arr=new Arraylist();
            #endregion

  
            // program.CompareString(LongString, shortString);//方法一


            //#region 方法二
            char[] arraylongs,arrayshorts;
            //arraylongs = LongString.ToCharArray();
            //arrayshorts = shortString.ToCharArray();
            //program.quick_sort(arraylongs, 0, LongString.Length-1);//排序
            //program.quick_sort(arrayshorts, 0, shortString.Length - 1);//排序

            //program.compare(arraylongs, arrayshorts);
            //#endregion
            Console.ReadLine();
        }
        #region 一、O(n*m)的轮询方法
        public bool CompareString(string LongString, string shortString)
        {
            int i, j;

            for ( i = 0; i < shortString.Length; i++)
            {
                for ( j = 0; j < LongString.Length; j++)
                {
                    if (LongString[j] == shortString[i])
                    {
                        break;
                    }
                }

                if (j == LongString.Length)
                {

                    Console.WriteLine("false");

                    return false;

                }

            }
            Console.WriteLine("true");
            return true;


        }
        #endregion


        #region 二、O(mlogm)+O(nlogn)+O(m+n)的排序方法

        //返回调整后基准数的位置
        public int addjustArray(char[] s, int start, int end)
        {
            int i = start, j = end;
            char x = s[start];//s[start]既[i]就是第一个坑

            while (i < j)
            {
                //从右到左找出小于x的数来填s[i]
                while (i < j&&s[j] >= x)
                    j--;

                if (i < j)
                {
                    s[i] = s[j];//将s[j]添到s[i]中，s[j]就形成了一个新的坑

                    i++;
         
                }

                //从左向右找大于或者等于x的数来填s[j]
                while (i < j&&s[i] < x)
                    i++;
                
                if (i < j)
                {
                    s[j] = s[i];

                    j--;
                }

                
            }
            s[i] = x;
            return i;
        
        }

        public void quick_sort(char[] s, int start, int end)
        {
            if (start < end)
            {
                int i = addjustArray(s, start, end);
                quick_sort(s, start, i - 1);
                quick_sort(s,i+1,end);
            
            }
        }

        public void compare(char[] str1, char[] str2)
        {
            int posOne = 0;
            int posTwo = 0;

            while (posTwo < str2.Length && posOne < str1.Length)
            {
                while (str1[posOne] < str2[posTwo] && posOne < str1.Length - 1)
                    posOne++;

                if (str1[posOne] != str2[posTwo])
                    break;

                posTwo++;
            
            }

            if (posTwo == str2.Length)
            {
                Console.WriteLine("true");
            }
            else
            {
                Console.WriteLine("false");
            }


        }

        #endregion
    }
}
