using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Csstack
{
    //class Program
    //{
    //    static void Main(string[] args)
    //    {
    //        Stack nums = new Stack();
    //        Stack ops = new Stack();
    //        string expression = "5+10+10+20";
    //        Calculate(nums, ops, expression);
    //        Console.WriteLine(nums.Pop());
    //        Console.Read();
    //    }

    //    //IsNumeric isn't built into c# so we must define it
    //    static bool IsNumberic(string input)
    //    {
    //        bool flag = true;
    //        string pattern = (@"^\d+$");
    //        Regex validate = new Regex(pattern);
    //        if (!validate.IsMatch(input))
    //        {
    //            flag = false;
    //        }
    //        return flag;
    //    }

    //    static void Calculate(Stack N, Stack O, string exp)
    //    {
    //        string ch, token = "";
    //        for (int p = 0; p < exp.Length; p++)
    //        {
    //            ch = exp.Substring(p, 1);
    //            if (IsNumberic(ch))
    //            {
    //                token += ch;
    //            }
    //            if (IsNumberic(ch) || p == (exp.Length - 1))
    //            {
    //                if (IsNumberic(token))
    //                {
    //                    N.Push(token);
    //                    token = "";

    //                }

    //            }
    //            else if (ch == "+" || ch == "-" || ch == "*" || ch == "/")
    //            {
    //                O.Push(ch);

    //            }
    //            if (N.Count == 2)
    //            {
    //                Compute(N, O);
    //            }



    //        }
    //    }

    //    static void Compute(Stack N, Stack O)
    //    {
    //        int oper1, oper2;
    //        string oper;
    //        oper1 = Convert.ToInt32(N.Pop());
    //        oper2 = Convert.ToInt32(N.Pop());

    //        oper = Convert.ToString(O.Pop());

    //        switch (oper)
    //        {
    //            case "+":
    //                N.Push(oper1 + oper2);
    //                break;
    //            case "-":
    //                N.Push(oper1 - oper2);
    //                break;

    //            case "*":
    //                N.Push(oper1 * oper2);
    //                break;

    //            case "/":
    //                N.Push(oper1 / oper2);
    //                break;
    //        }


    //    }
    //}

    //class Class1
    //{
    //    static void Main(string[] args)
    //    {
    //        int num, baseNum;
    //        Console.Write("Enter a decimal");
    //        num = Convert.ToInt32(Console.ReadLine());
    //        Console.Write("Enter a base");
    //        baseNum = Convert.ToInt32(Console.ReadLine());
    //        Console.Write(num + " convert to");
    //        MulBase(num,baseNum);
    //        Console.WriteLine("Base"+baseNum);
    //        Console.Read();
        
    //    }

    //    static void MulBase(int n, int b)
    //    {
    //        Stack Digits = new Stack();
    //        do
    //        {
    //            Digits.Push(n % b);
    //            n /= b;

    //        }while(n!=0);
    //        while (Digits.Count > 0)
    //        {
    //            Console.Write(Digits.Pop());
    //        }
        
    //    }

    //}

    class Class2
    {
        static void Main(string[] args)
        {

            Class2 cl2 = new Class2();

            cl2.testfun(test.test2);

            Console.ReadLine();
        
        }

         void testfun(test testnum)
        {
            if ((int)testnum == 1)
            {
                Console.WriteLine("HAHAHAHAH");
            }
            if ((int)testnum == 2)
            {
                Console.WriteLine("aaaaaaaa");
            }
            if ((int)testnum == 3)
            {
                Console.WriteLine("bbbbbbbb");
            }
        }

        public enum test
        { 
            test1 = 1,
            test2 = 2,
            test3 = 3
        
        }
    }
}
