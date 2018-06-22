using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Common;
using Model;
using System.Text;
using System.Reflection;
using  System.Web.SessionState;

namespace Web.ashx
{
    /// <summary>
    /// 导入Excel
    /// </summary>
    public class ImportExcel : IHttpHandler,IRequiresSessionState 
    {

        private string cmd;
        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            try
            {
                cmd = context.Request["cmd"].ToString();
                #region
                if (cmd != null)
                {
                    try
                    {
                        MethodInfo method = this.GetType().GetMethod(cmd);
                        if (method != null)
                        {
                            context.Response.Write(method.Invoke(this, new object[] { context }));
                        }
                    }
                    catch
                    {
                        context.Response.Write("无效的运行参数!");
                    }
                }
                else
                {
                    context.Response.Write("调用接口未定义！");
                }
                #endregion
            }
            catch
            { }

            context.Response.End();
        }

       public  List<UserEntity> enlist = new List<UserEntity>();
       public void import(HttpContext context)
        {
            StringBuilder errorMsg = new StringBuilder(); // 错误信息
            try
            {

                #region 1.获取Excel文件并转换为一个List集合

                // 1.1存放Excel文件到本地服务器
                HttpPostedFile filePost = context.Request.Files["filed"]; // 获取上传的文件
                string filePath = ExcelHelper.SaveExcelFile(filePost); // 保存文件并获取文件路径

                // 单元格抬头
                // key：实体对象属性名称，可通过反射获取值
                // value：属性对应的中文注解
                Dictionary<string, string> cellheader = new Dictionary<string, string> { 
                    { "Name", "1列" }, 
                    { "Age", "2列" }, 
                    { "Gender", "3列" }, 
                    //{ "TranscriptsEn.ChineseScores", "语文成绩" }, 
                    //{ "TranscriptsEn.MathScores", "数学成绩" }, 
                };

                // 1.2解析文件，存放到一个List集合里
               enlist = ExcelHelper.ExcelToEntityList<UserEntity>(cellheader, filePath, out errorMsg);

                #endregion

                #region 2.对List集合进行有效性校验

                //#region 2.1检测必填项是否必填

                //for (int i = 0; i < enlist.Count; i++)
                //{
                //    UserEntity en = enlist[i];
                //    string errorMsgStr = "第" + (i + 1) + "行数据检测异常：";
                //    bool isHaveNoInputValue = false; // 是否含有未输入项
                //    if (string.IsNullOrEmpty(en.Name))
                //    {
                //        errorMsgStr += "姓名列不能为空；";
                //        isHaveNoInputValue = true;
                //    }
                //    if (isHaveNoInputValue) // 若必填项有值未填
                //    {
                //        en.IsExcelVaildateOK = false;
                //        errorMsg.AppendLine(errorMsgStr);
                //    }
                //}

                //#endregion

                //#region 2.2检测Excel中是否有重复对象

                //for (int i = 0; i < enlist.Count; i++)
                //{
                //    UserEntity enA = enlist[i];
                //    if (enA.IsExcelVaildateOK == false) // 上面验证不通过，不进行此步验证
                //    {
                //        continue;
                //    }

                //    for (int j = i + 1; j < enlist.Count; j++)
                //    {
                //        UserEntity enB = enlist[j];
                //        // 判断必填列是否全部重复
                //        if (enA.Name == enB.Name)
                //        {
                //            enA.IsExcelVaildateOK = false;
                //            enB.IsExcelVaildateOK = false;
                //            errorMsg.AppendLine("第" + (i + 1) + "行与第" + (j + 1) + "行的必填列重复了");
                //        }
                //    }
                //}

                //#endregion

                // TODO：其他检测

                #endregion

                // 3.TODO：对List集合进行持久化存储操作。如：存储到数据库
                
                // 4.返回操作结果
                bool isSuccess = false;
                if (errorMsg.Length == 0)
                {
                    isSuccess = true; // 若错误信息成都为空，表示无错误信息
                }
                var rs = new { success = isSuccess,  msg = errorMsg.ToString(), data = enlist };
                System.Web.Script.Serialization.JavaScriptSerializer js = new System.Web.Script.Serialization.JavaScriptSerializer();
                context.Response.ContentType = "text/plain";
                context.Response.Write(js.Serialize(rs)); // 返回Json格式的内容
                string aa = js.Serialize(rs);
                if (aa == null)
                { }
                //context.Session.Add("en", enlist);
                //context.Session.Add("en", enlist);
                HttpContext.Current.Session["en"] = enlist;
                //context.Session.se
                //export(context);
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





        #region

        public void export(HttpContext context)
        {
            try
            {
                enlist = (List<UserEntity>)HttpContext.Current.Session["en"];
               

                // 2.设置单元格抬头
                // key：实体对象属性名称，可通过反射获取值
                // value：Excel列的名称
                Dictionary<string, string> cellheader = new Dictionary<string, string> { 
                    { "Name", "" },
                    { "Age", "" },
                    { "Gender", "" },
                    //{ "TranscriptsEn.ChineseScores", "语文成绩" },
                    //{ "TranscriptsEn.MathScores", "数学成绩" },
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

        public bool IsReusable1
        {
            get
            {
                return false;
            }
        }

        #endregion
    }
}