using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace CollectionStudy
{
    class Program
    {

        static void Main(string[] args)
        {
           
            Collection names = new Collection();
            names.Add("悟空");
            names.Add("悟能");
            names.Add("悟净");
            names.Add("三藏");
            names.Add("释迦牟尼");

            foreach (Object name in names)
            {
                Console.WriteLine(name);
            }
            Console.WriteLine("Number of names:"+names.Count());
            names.Remove("释迦牟尼");
            Console.WriteLine("Number of names:" + names.Count());
            names.Clear();
            Console.WriteLine("Number of names:" + names.Count());
            Console.ReadKey();
        }
    }

    public class Collection:CollectionBase
    {
        public void Add(Object item)
        {
            InnerList.Add(item);//ArrayList把数据作为Object来存储
        }

        public void Remove(Object item)
        {
            InnerList.Remove(item);
        }
        /// <summary>
        /// 由于是在基础类CollectionBase中实现Count,
        /// 所以必须用 新的 关键词来隐藏在CollectionBase中找到Count的定义(!!!没有看懂，所以记下来)
        /// </summary>
        /// <returns></returns>
        public new int Count()
        {
            return InnerList.Count;
        }

        public new void Clear()
        {
            InnerList.Clear();
        }
    }
}
