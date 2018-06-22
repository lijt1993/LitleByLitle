using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelFirst
{
    class Program
    {
        static void Main(string[] args)
        {
            #region 添加数据
            //1.声明上下文
            ModelFirstModelContainer dbContext = new ModelFirstModelContainer();
            //2.对数据库的操作，添加数据
            //2.1实例化实体，对实体赋值
            user u = new user();

            u.Id = 1;
            u.Name = "Ares";
            u.CreateDate = DateTime.Now.ToString();
            //2.2 增实体附加到上下文
            dbContext.userSet.Attach(u);
            //添加到数据库
            dbContext.Entry(u).State = System.Data.EntityState.Added;
            #endregion
            //3.保存
            dbContext.SaveChanges();

            #region 查看数据库数据
            //方法一、使用Linq语句查询
            card c = new card();
            
            //1.Linq语句
            var item = from s in dbContext.cardSet
                       select s;
            //遍历查询出来的内容
            foreach(var cardId in item)
            {
                Console.WriteLine("Linq查询结果是："+cardId.Id);
            }

            //方法二、使用lambda查询
            var itemlambda = dbContext.cardSet.Where<card>(s => s.Id == 1).FirstOrDefault();
            Console.WriteLine("lambda查询id结果是" + itemlambda.Id);
            #endregion
        }
    }
}
