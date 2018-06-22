using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace Yuesefu
{
    class Program
    {
        int N = 41;
        int M = 3;
        static void Main(string[] args)
        {
            
            //System.ValueType tt = null;
              // System.Object
            //string 
            Program P = new Program();
            BinaryFormatter bf = new BinaryFormatter();
            MemoryStream ms = new MemoryStream();
            String result = "";
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append("");
            //bf.Serialize(ms, this); 
            int[] man = new int[P.N];
            int count = 1;
            int i = 0, pos = -1;
            int alive = 0;

            while (count <= P.N)
            {
                do
                {
                    pos = (pos + 1) % P.N;
                    if (man[pos] == 0)
                    {

                        i++;
                    }
                    if (i == P.M)
                    {

                        i = 0;
                        break;
                    }
                } while (true);

                man[pos] = count;
                count++;
            }
            Console.WriteLine("");
            Console.ReadLine();

        }
    }
}
