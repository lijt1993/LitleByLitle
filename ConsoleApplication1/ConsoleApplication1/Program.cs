using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace MyConsole
{
    class UnboxPerformance
    {
        #region 装箱与拆箱

        /*将5000000条记录写入到ArrayList并将数据在读取出来的工作做5遍。
         *其中，写入和读取ArrayList的工作就是装箱拆箱的工作
         
         */
        private static void RunUnbox()
        {
            int count;
            DateTime startTime = DateTime.Now;
            ArrayList MyArrayList = new ArrayList();
            //List<int> myTlist = new List<int>();
            for (int i = 5; i > 0; i--) //重复5次测试
            {
                MyArrayList.Clear();
                for (count = 0; count < 5000000; count++)
                    MyArrayList.Add(count);//装箱，将值类型加入MyArrayList数据
                int j;//重新得到新值
                for (count = 0; count < 5000000; count++)
                    j = (int)MyArrayList[count];//拆箱

            }
            DateTime endTime = DateTime.Now;
            Console.WriteLine("使用装箱拆箱的数据-- 开始时间 {0}\n结束时间{1}\n 花费时间 {2}",startTime,endTime,endTime - startTime);

        }


        #endregion

        #region 使用泛型集合，不进行装箱拆箱操作

        private static void RunNoUnbox()
        {
            int count;
            DateTime  startTime = DateTime.Now;
            List<int> myTlist = new List<int>();
            for (int i = 5; i > 0; i--)
            {
                myTlist.Clear();
                for (count = 0; count < 5000000; count++)
                    myTlist.Add(count);//将值类型加入泛型数组

                int j;
                for (count = 0; count < 5000000; count++)
                    j = myTlist[count];
            
            }
            DateTime endTime = DateTime.Now;
            Console.WriteLine("使用泛型 -- 开始时间{0}\n结束时间{1}\n花费时间{2}",
                startTime,endTime,endTime-startTime);

        
        }

        #endregion





        static void Main(string[] args)
        {
            RunUnbox(); //调用装箱拆箱的方法
            RunNoUnbox();//调用使用泛型集合的方法
            Console.WriteLine("请输入任意键，结束运行");
            Console.ReadLine();
            
        }
    }
}
