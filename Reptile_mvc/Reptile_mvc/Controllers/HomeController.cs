using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Mvc;

namespace Reptile_mvc.Controllers
{
    public class HomeController : Controller
    {
        public void Index()
        {
             //抓取整本小说
            HomeController cra = new HomeController();//顶点抓取小说网站小说
            string html = cra.HttpGet("http://www.23us.so/files/article/html/13/13655/index.html", "");

            //获取小说名字
            Match ma_name = Regex.Match(html, @"<meta name=""keywords"".+content=""(.+)""/>");
            string name = ma_name.Groups[1].Value.ToString().Split(',')[0];

            //获取章节目录
            Regex reg_mulu = new Regex(@"<table cellspacing=""1"" cellpadding=""0"" bgcolor=""#E4E4E4"" id=""at"">(.|\n)*?</table>");
            var mat_mulu = reg_mulu.Match(html);
            string mulu = mat_mulu.Groups[0].ToString();

            //匹配a标签里面的url
            Regex tmpreg = new Regex("<a[^>]+?href=\"([^\"]+)\"[^>]*>([^<]+)</a>", RegexOptions.Compiled);
            MatchCollection sMC = tmpreg.Matches(mulu);
            if (sMC.Count != 0)
            {
                //循环目录url，获取正文内容
                for (int i = 0; i < sMC.Count; i++)
                {
                    //sMC[i].Groups[1].Value
                    //0是<a href="http://www.23us.so/files/article/html/13/13655/5638725.html">第一章 泰山之巅</a> 
                    //1是http://www.23us.so/files/article/html/13/13655/5638725.html
                    //2是第一章 泰山之巅

                    //获取章节标题
                    string title = sMC[i].Groups[2].Value;

                    //获取文章内容
                    string html_z = cra.HttpGet(sMC[i].Groups[1].Value, "");

                    //获取小说名字,章节中也可以查找名字
                    //Match ma_name = Regex.Match(html, @"<meta name=""keywords"".+content=""(.+)"" />");
                    //string name = ma_name.Groups[1].Value.ToString().Split(',')[0];

                    //获取标题,通过分析h1标签也可以得到章节标题
                    //string title = html_z.Replace("<h1>", "*").Replace("</h1>", "*").Split('*')[1];

                    //获取正文
                    Regex reg = new Regex(@"<dd id=""contents"">(.|\n)*?</dd>");
                    MatchCollection mc = reg.Matches(html_z);
                    var mat = reg.Match(html_z);
                    string content = mat.Groups[0].ToString().Replace("<dd id=\"contents\">", "").Replace("</dd>", "").Replace("&nbsp;", "").Replace("<br />", "\r\n");

                    //txt文本输出
                    string path = AppDomain.CurrentDomain.BaseDirectory.Replace("\\", "/") + "Txt/";
                    Novel(title + "\r\n" + content, name, path);
                }
            }
        }



            /// <summary>
        /// 创建文本
        /// </summary>
        /// <param name="content">内容</param>
        /// <param name="name">名字</param>
        /// <param name="path">路径</param>
        public void Novel(string content, string name, string path)
        {
            string Log = content + "\r\n";
            //创建文件夹，如果不存在就创建file文件夹
            if (Directory.Exists(path) == false)
            {
                Directory.CreateDirectory(path);
            }

            //判断文件是否存在，不存在则创建
            if (!System.IO.File.Exists(path + name + ".txt"))
            {
                FileStream fs1 = new FileStream(path + name + ".txt", FileMode.Create, FileAccess.Write);//创建写入文件 
                StreamWriter sw = new StreamWriter(fs1);
                sw.WriteLine(Log);//开始写入值
                sw.Close();
                fs1.Close();
            }
            else
            {
                FileStream fs = new FileStream(path + name + ".txt" + "", FileMode.Append, FileAccess.Write);
                StreamWriter sr = new StreamWriter(fs);
                sr.WriteLine(Log);//开始写入值
                sr.Close();
                fs.Close();
            }
        }



           //Post
        public string HttpPost(string Url, string postDataStr)
        {
            CookieContainer cookie = new CookieContainer();
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(Url);
            request.Method = "POST";
            request.ContentType = "application/x-www-form-urlencoded";
            request.ContentLength = Encoding.UTF8.GetByteCount(postDataStr);
            request.CookieContainer = cookie;
            Stream myRequestStream = request.GetRequestStream();
            StreamWriter myStreamWriter = new StreamWriter(myRequestStream, Encoding.GetEncoding("gb2312"));
            myStreamWriter.Write(postDataStr);
            myStreamWriter.Close();

            HttpWebResponse response = (HttpWebResponse)request.GetResponse();

            response.Cookies = cookie.GetCookies(response.ResponseUri);
            Stream myResponseStream = response.GetResponseStream();
            StreamReader myStreamReader = new StreamReader(myResponseStream, Encoding.GetEncoding("utf-8"));
            string retString = myStreamReader.ReadToEnd();
            myStreamReader.Close();
            myResponseStream.Close();

            return retString;
        }


         //Get
        public string HttpGet(string Url, string postDataStr)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(Url + (postDataStr == "" ? "" : "?") + postDataStr);
            request.Method = "GET";
            HttpWebResponse response;
            request.ContentType = "text/html;charset=UTF-8";
            try
            {
                response = (HttpWebResponse)request.GetResponse();
            }
            catch (WebException ex)
            {
                response = (HttpWebResponse)request.GetResponse();
            }

            Stream myResponseStream = response.GetResponseStream();
            StreamReader myStreamReader = new StreamReader(myResponseStream, Encoding.GetEncoding("utf-8"));
            string retString = myStreamReader.ReadToEnd();
            myStreamReader.Close();
            myResponseStream.Close();

            return retString;
        }
    
    
    }
}
