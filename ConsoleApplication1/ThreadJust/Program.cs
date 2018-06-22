using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ThreadJust
{
    class Program
    {
        static void Main(string[] args)
        {
            // 打印阈值和可用数量
            GetLimitation();
            GetAvailable();

            // 使用掉其中三个线程
            Console.WriteLine("此处申请使用3个线程...");
            ThreadPool.QueueUserWorkItem(Work);
            ThreadPool.QueueUserWorkItem(Work);
            ThreadPool.QueueUserWorkItem(Work);

            Thread.Sleep(1000);

            // 打印阈值和可用数量
            GetLimitation();
            GetAvailable();
            // 设置最小值
            Console.WriteLine("此处修改了线程池的最小线程数量");
            ThreadPool.SetMinThreads(10, 10);
            // 打印阈值
            GetLimitation();

            Console.ReadKey();
        }


        // 运行10s的方法
        private static void Work(object o)
        {
            Thread.Sleep(10 * 1000);
        }

        // 打印线程池的上下限阈值
        private static void GetLimitation()
        {
            int maxWork, minWork, maxIO, minIO;
            // 得到阈值上限
            ThreadPool.GetMaxThreads(out maxWork, out maxIO);
            // 得到阈值下限
            ThreadPool.GetMinThreads(out minWork, out minIO);
            // 打印阈值上限
            Console.WriteLine("线程池最多有{0}个工作者线程，{1}个IO线程", maxWork.ToString(), maxIO.ToString());
            // 打印阈值下限
            Console.WriteLine("线程池最少有{0}个工作者线程，{1}个IO线程", minWork.ToString(), minIO.ToString());
            Console.WriteLine("------------------------------------");
        }

        // 打印可用线程数量
        private static void GetAvailable()
        {
            int remainWork, remainIO;
            // 得到当前可用线程数量
            ThreadPool.GetAvailableThreads(out remainWork, out remainIO);
            // 打印可用线程数量
            Console.WriteLine("线程池中当前有{0}个工作者线程可用，{1}个IO线程可用", remainWork.ToString(), remainIO.ToString());
            Console.WriteLine("------------------------------------");
        }
    }
}
