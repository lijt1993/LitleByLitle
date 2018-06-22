using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IsAndAs
{
    class Program
    {
        //is运算符
        //as符语法
        static void Main(string[] args)
        {
            A a = new A();
            B b = new B();

            #region  is运算符

            //is运算符用于检查对象是否与给定类型兼容。如果兼容返回true,反之返回false
            //object is objectType
           
            if (a is A)//使用is运算，来判断a与A是否是同一类型
                Console.WriteLine("a与A是同一类型");
            else
                Console.WriteLine("a与A是不同类型");
            if (b is A)
                Console.WriteLine("b与A是同一类型");
            else
                Console.WriteLine("b与A不是同一类型");

       

            #endregion


            #region
            a.i = 5;
            A c = a as A;
            Console.WriteLine(c.i.ToString());
            
            #endregion

            Console.Read();


        }
    }


    class A {
       public  int i;
    }
    class B { }
}
