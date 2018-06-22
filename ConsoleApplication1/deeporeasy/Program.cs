using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace deeporeasy
{

    public class DeepCopy : ICloneable
    {
        public int i = 0;
        public A a = new A();

        public object Clone()
        {
            // 实现深复制-方式1：依次赋值和实例化
            DeepCopy newObj = new DeepCopy();
            newObj.a = new A();
            newObj.a.message = this.a.message;
            newObj.i = this.i;

            return newObj;
        }

        public new object MemberwiseClone()
        {
            // 实现浅复制
            return base.MemberwiseClone();
        }

        public override string ToString()
        {
            string result = string.Format("I的值为{0},A为{1}", this.i.ToString(), this.a.message);
            return result;
        }
    }

    public class A
    {
        public string message = "我是原始A";
    }


    class Program
    {
        static void Main(string[] args)
        {

            DeepCopy dc = new DeepCopy();
            dc.i = 10;
            dc.a = new A();

            DeepCopy deepClone = dc.Clone() as DeepCopy;
            DeepCopy shadowClone = dc.MemberwiseClone() as DeepCopy;

            // 深复制的目标对象将拥有自己的引用类型成员对象
            deepClone.a.message = "我是深复制的A";
            Console.WriteLine(dc);
            Console.WriteLine(deepClone);
            Console.WriteLine();
            // 浅复制的目标对象将和原始对象共享引用类型成员对象
            shadowClone.a.message = "我是浅复制的A";
            Console.WriteLine(dc);
            Console.WriteLine(shadowClone);

            Console.ReadKey();
        }

    }
}
