using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortTest
{
    class Carry
    {
        public  int[] arr;
        public int upper;
        public  int numElements;

        public Carry(int size)
        {
            arr = new int[size];
            upper = size - 1;
            numElements = 0;
        }

        public void insert(int item)
        {
            arr[numElements] = item;
            numElements++;
        }

        public void DisplayElements()
        {
            for (int i = 0; i <= upper; i++)
            {
                Console.Write(arr[i]+" ");
            }
            Console.WriteLine();
        }

        public void Clear()
        {
            for (int i = 0; i <= upper; i++)
            {
                arr[i] = 0;
            }
            numElements = 0;

        }


        #region 冒泡排序

        public void BubbleSort()
        {
            int temps;
            for (int i = upper - 1; i >= 0; i--)
            {

                for (int j = 0; j <= i; j++)
                {
                    if ((int)arr[j] > arr[j + 1])
                    {
                        temps = arr[j];
                        arr[j] = arr[j + 1];
                        arr[j + 1] = temps;
                    }

                }

              //  this.DisplayElements(); 
       //         Console.WriteLine();
            }


        }

        #endregion


        #region 选择排序
        public void selectionSort()
        {
            int min, temp;
            for (int i = 0; i < upper; i++)
            {
                min = i;
                for (int j = i + 1; j <= upper; j++)
                {
                    if (arr[j] < arr[min])
                    {
                         min = j;
                    }
                
                }

                temp = arr[i];
                arr[i] = arr[min];
                arr[min] = temp;
               // this.DisplayElements();
              //  Console.WriteLine();
            }
        
        
        }

        #endregion


        #region 插入排序

        public void InsertSort()
        {
            int temp;//定义一个变量，存放要插入的元素
            for (int i = 1; i <= upper; i++)//循环要插入的元素
            {
                temp = arr[i];
                int j = i - 1;//与要插入元素做比较的光标
                while (j >= 0 && arr[j] > temp)
                {
                    //做比较的元素大于要插入的元素，做比较的元素后移
                    arr[j + 1] = arr[j];
                    j--;
                }
                //将要插入的元素插入到适当位置
                arr[j + 1] = temp;

               // this.DisplayElements();
               // Console.WriteLine();
            }
        
        
        }

        #endregion

    }
}
