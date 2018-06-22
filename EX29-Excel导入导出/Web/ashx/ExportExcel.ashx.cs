using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Model;
using Common;
using System.Collections;


namespace Web.ashx
{
    /// <summary>
    /// 导出Excel
    /// </summary>
    public class ExportExcel: IHttpHandler
    {
      
        public void ProcessRequest(HttpContext context)
        {
            try
            {
                string strlist  = context.Request.Params["list"];
                
               
               // Person[] personArray = myPerson.GetPersons();
               // ArrayList personList = ArrayList.Adapter(personArray);
                string [] flagarry = strlist.Split('}');
                ArrayList flagliist = ArrayList.Adapter(flagarry);
                //if (flagliist == null)
                //{
                //    List<UserEntity> enlist = new List<UserEntity>();
                    
                //    foreach (UserEntity item in enlist)
                //    {
                        

                //        //item.C_DEP = listEmp.Where(u => u.PKID == item.EMP_PKID).FirstOrDefault().C_DEP.ToString();//部门
                //        //item.PRODUCTION_GROUP = listEmp.Where(u => u.PKID == item.EMP_PKID).FirstOrDefault().PRODUCTION_GROUP;//车间
                //        //item.C_PERSON_AGE = listEmp.Where(u => u.PKID == item.EMP_PKID).FirstOrDefault().C_PERSON_AGE.ToString();//年龄
                //        //item.C_PERSON_SEX = listEmp.Where(u => u.PKID == item.EMP_PKID).FirstOrDefault().C_PERSON_SEX.ToString();//性别
                //        //item.C_NAME = listEmp.Where(u => u.PKID == item.EMP_PKID).FirstOrDefault().C_NAME.ToString();//姓名

                //    }
                //}
              //  List<UserEntity> enlist = new List<UserEntity>()
              //  { 
              //  // 1.获取数据集合
              //  // 1.获取数据集合
                List<UserEntity> enlist = new List<UserEntity>() { 


                    new UserEntity{Name="刘一",Age="22",Gender="Male"},
                    new UserEntity{Name="陈二",Age="23",Gender="Male" },
                    new UserEntity{Name="张三",Age="24",Gender="Male"},
                    new UserEntity{Name="李四",Age="25",Gender="Male" },
                    new UserEntity{Name="王五",Age="26",Gender="Male"},
                    new UserEntity{Name="赵六",Age="27",Gender="Male"},



                    //new UserEntity{Name="刘一",Age=22,Gender="Male",TranscriptsEn=new TranscriptsEntity{ChineseScores=80,MathScores=90}},
                    //new UserEntity{Name="陈二",Age=23,Gender="Male",TranscriptsEn=new TranscriptsEntity{ChineseScores=81,MathScores=91} },
                    //new UserEntity{Name="张三",Age=24,Gender="Male",TranscriptsEn=new TranscriptsEntity{ChineseScores=82,MathScores=92} },
                    //new UserEntity{Name="李四",Age=25,Gender="Male",TranscriptsEn=new TranscriptsEntity{ChineseScores=83,MathScores=93} },
                    //new UserEntity{Name="王五",Age=26,Gender="Male",TranscriptsEn=new TranscriptsEntity{ChineseScores=84,MathScores=94} },
              
                
                
                };

                // 2.设置单元格抬头
                // key：实体对象属性名称，可通过反射获取值
                // value：Excel列的名称
                Dictionary<string, string> cellheader = new Dictionary<string, string> { 
                    { "Name", "" }, 
                    { "Age", "" }, 
                    { "Gender", "" }, 
                };

                // 3.进行Excel转换操作，并返回转换的文件下载链接
                string urlPath = ExcelHelper.EntityListToExcel2003(cellheader, enlist, "学生成绩");
                System.Web.Script.Serialization.JavaScriptSerializer js = new System.Web.Script.Serialization.JavaScriptSerializer();
                context.Response.ContentType = "text/plain";
                context.Response.Write(js.Serialize(urlPath)); // 返回Json格式的内容
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}