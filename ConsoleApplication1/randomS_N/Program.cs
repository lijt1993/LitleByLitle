using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace randomS_N
{
    class Program
    {
       // Program po = new Program();
        static void Main(string[] args)
        {
            Program po1 = new Program();

            po1.GetRandomNum(4,15);
            
            
        }

        public void GetRandomNum(int s,int n)
        {
            
            int[] index = new int[n];
            for (int i = 0; i < n; i++)
                index[i] = i;
            Random r = new Random();
            //用来保存随机生成的不重复的10个数 
            int[] result = new int[s];
            int site = n;//设置上限 
            int id;
            for (int j = 0; j < s; j++)
            {
                id = r.Next(1, site - 1);
                //在随机位置取出一个数，保存到结果数组 
                result[j] = index[id];
                //最后一个数复制到当前位置 
                index[id] = index[site - 1];
                //位置的上限减少一 
                site--;
            }
            
            //排序
            this.Sort(result);

            //int[] array = new int[s + 1];
            result[s-1] = n;

            Console.WriteLine(result[0]);
            for (int i = 1; i < result.Length; i++)
            {
                Console.WriteLine(result[i] - result[i - 1]);

                Console.WriteLine();
            }



            foreach (int aa in result)
            {
                Console.WriteLine(aa);
            }
            Console.ReadKey();
        }

        private void Sort(int[] result)
        {

            for (int i = 0; i < result.Length; i++)
            {
                for (int j = i + 1; j < result.Length; j++)
                {
                    if (result[i] > result[j])
                    {
                        result[i] ^= result[j];
                        result[j] ^= result[i];
                        result[i] ^= result[j];
                    }
                
                }
            
            }
        }
    }


}
