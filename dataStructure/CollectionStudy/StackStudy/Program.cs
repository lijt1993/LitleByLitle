using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StackStudy
{
    class Program
    {
        static void Main(string[] args)
        {
            
            CStack alist = new CStack();
            string ch;
            string word = "jmj";
            bool isPalindrome = true;
            for (int x = 0; x < word.Length; x++)
            {
                alist.push(word.Substring(x,1));
            }
            int pos = 0;
            while (alist.count > 0)
            {
                ch = alist.pop().ToString();
                if (ch != word.Substring(pos, 1))
                {
                    isPalindrome = false;
                    break;
                }
                pos++;
            }
            if (isPalindrome)
            {
                Console.WriteLine(word + " is a palindrome");
            }
            else
            {
                Console.WriteLine(word+" is not a palindrome");
            }
            Console.Read();
        }
    }
}
