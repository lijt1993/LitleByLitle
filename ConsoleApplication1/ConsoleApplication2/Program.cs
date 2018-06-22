using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    //值类型和引用类型赋值的区别
    class ValueTypeAndRefType
    {
        class SomeRef
        {
           
            public int x;
        }
        struct SomeVal
        {
            public int x;
        }

        static void Main(string[] args)
        {
            SomeRef Referencel = new SomeRef();//分配在托管堆上
            SomeVal Valuel = new SomeVal();//分配在堆栈上
            Referencel.x = 3;              //解析指针
            Valuel.x = 3;                  //在堆栈上修改



            Console.WriteLine("引用类型：Referencel=" + Referencel.x);
            //显示为“3”
            Console.WriteLine("值类型：Valuel=" + Valuel.x);//显示为“3”
            SomeRef Reference2 = Referencel;     //仅复制引用（指针）
            SomeVal Value2 = Valuel;            //先在堆栈上分配，然后复制成员

            Referencel.x = 8;                 //改变了Referencel.x和Reference2.x
            Valuel.x = 7;                     //改变了Valuel.x,没有改变Value2.x
            Console.WriteLine("引用类型：Referencel  " + Referencel.x);
            Console.WriteLine("引用类型：Reference2  " + Reference2.x);
            Console.WriteLine("值类型：Valuel  " + Valuel.x);
            Console.WriteLine("值类型：Value2  " + Value2.x);
            Console.ReadLine();

        }



    }
}
