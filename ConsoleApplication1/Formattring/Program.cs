using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Formattring
{
    class Program
    {
        static void Main(string[] args)
        {
             
            var currentTime = System.DateTime.Now;

            //获取当前时间的年、月、日
            int 年 = currentTime.Year;
            int 月 = currentTime.Month;
            int 日 = currentTime.Day;

            //获取当前时间的时、分、秒
            int 时 = currentTime.Hour;
            int 分 = currentTime.Minute;
            int 秒 = currentTime.Second;
            int 毫秒 = currentTime.Millisecond;

            //获取中文日期显示---年月日时分的示例代码如下
            string strY = currentTime.ToString("f");//不显示毫秒

            //获取本季度的第一天
            string one = currentTime.AddMonths(0 - ((月 - 1) % 3)).ToString("yyyy-MM-01");
           
            //string flag = currentTime.AddMonths(1).ToString("yyyy-MM-dd");
           
            //获取本季度的最后一天
            string last = DateTime.Parse(currentTime.AddMonths(3 - (月 - 1) % 3).ToString("yyyy-MM-01")).AddDays(-1).ToShortDateString();
            
            //获取下一个季度
            string next_one = currentTime.AddMonths(3 - ((月 - 1) % 3)).ToString("yyyy-MM-01");//第一天
            string next_last = DateTime.Parse(currentTime.AddMonths(3 - (月 - 1) % 3).ToString("yyyy-MM-01")).AddDays(-1).ToShortDateString();//最后一天

            //获取上一个季度
            string previous_one = currentTime.AddMonths(-3 - ((月 - 1) % 3)).ToString("yyyy-MM-01");//第一天
            string previous_last = DateTime.Parse(currentTime.AddMonths(0 - (月 - 1) % 3).ToString("yyyy-MM-01")).AddDays(-1).ToShortDateString();//最后一天



            Console.WriteLine(one);
            Console.WriteLine(last);
            Console.WriteLine(next_one);
            Console.WriteLine(next_last);
            Console.WriteLine(previous_one);
            Console.WriteLine(previous_last);
             Console.ReadLine();
        }
    }
}
