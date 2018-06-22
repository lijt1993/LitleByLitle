using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBFirst
{
    class Program
    {
        static void Main(string[] args)
        {
            #region 更新操作
            //1.声明上下文
            EFModelFirst1Entities dbContext = new EFModelFirst1Entities();
            //2.对实体操作
            //2.1 实例化要操作的实体,并赋值
            userSet user = new userSet();
            //更改属性， 必须给所有属性赋值   
            user.Id = 4;       
            user.Name = "Ares";
            user.CreateDate = DateTime.Now.ToString();
            //user.Email = "18333602097@163.com";
            //2.2 实体附加到上下文,并进行操作。
            //实体附加到上下文
            dbContext.userSet.Attach(user);
            //dbContext.Entry(user).State = EntityState.Modified;    //实体已修改。
            //dbContext.Entry(user).State = EntityState.Deleted;   //标记实体以进行删除。
            //dbContext.Entry(user).State = EntityState.Unchanged; //实体处于原始的、未经修改的状态。
            dbContext.Entry(user).State = EntityState.Added;     //添加操作
            //dbContext.Entry(user).State = EntityState.Detached;  //实体未附加，也未处于被跟踪状态。

            //3.调用SaveChange保存
            dbContext.SaveChanges();
            #endregion
        }
    }
}
