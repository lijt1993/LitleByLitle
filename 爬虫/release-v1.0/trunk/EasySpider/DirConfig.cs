using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace EasySpider
{
    /// <summary>
    /// 此类存储所有资源的保存路径
    /// </summary>
    public class DirConfig
    {
        private string htmlDirPath;
        private string imgDirPath;
        private string jsDirPath;
        private string cssDirPath;
        private string flashDirPath;

        /// <summary>
        /// 页面保存文件夹完整路径
        /// </summary>
        public string HtmlDirPath
        {
            get { return htmlDirPath; }
            set { htmlDirPath = value; }
        }

        /// <summary>
        /// 图片保存文件夹完整路径
        /// </summary>
        public string ImgDirPath
        {
            get { return imgDirPath; }
            set { imgDirPath = value; }
        }

        /// <summary>
        /// JS保存文件夹完整路径
        /// </summary>
        public string JsDirPath
        {
            get { return jsDirPath; }
            set { jsDirPath = value; }
        }

        /// <summary>
        /// CSS保存文件夹完整路径
        /// </summary>
        public string CssDirPath
        {
            get { return cssDirPath; }
            set { cssDirPath = value; }
        }

        /// <summary>
        /// Flash保存文件夹完整路径
        /// </summary>
        public string FlashDirPath
        {
            get { return flashDirPath; }
            set { flashDirPath = value; }
        }
        

        public DirConfig(string htmlDirPath)
            : this(htmlDirPath, null, null, null, null)
        {

        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="htmlDirPath">页面保存文件夹完整路径</param>
        /// <param name="imgDirPath">图片保存文件夹完整路径</param>
        /// <param name="jsDirPath">JS保存文件夹完整路径</param>
        /// <param name="cssDirPath">CSS保存文件夹完整路径</param>
        /// <param name="flashDirPath">Flash保存文件夹完整路径</param>
        public DirConfig(string htmlDirPath, string imgDirPath, string jsDirPath, string cssDirPath, string flashDirPath)
        {
            this.htmlDirPath = htmlDirPath;
            this.imgDirPath = imgDirPath;
            this.jsDirPath = jsDirPath;
            this.cssDirPath = cssDirPath;
            this.flashDirPath = flashDirPath;
            if (string.IsNullOrEmpty(imgDirPath))
            {
                this.imgDirPath = htmlDirPath + @"\img";
            }
            if (string.IsNullOrEmpty(jsDirPath))
            {
                this.jsDirPath = htmlDirPath + @"\js";
            }
            if (string.IsNullOrEmpty(cssDirPath))
            {
                this.cssDirPath = htmlDirPath + @"\css";
            }
            if (string.IsNullOrEmpty(flashDirPath))
            {
                this.flashDirPath = htmlDirPath + @"\flash";
            }
        }

        

        /// <summary>
        /// 检查所有路径是否在同一个磁盘下
        /// </summary>
        /// <returns>如果是则返回true，否则返回false</returns>
        public bool CheckLegal()
        {
            string[] arr;
            string drive;
            this.StrictPath();
            if (string.IsNullOrEmpty(htmlDirPath) || string.IsNullOrEmpty(imgDirPath) || string.IsNullOrEmpty(cssDirPath) || string.IsNullOrEmpty(jsDirPath) || string.IsNullOrEmpty(flashDirPath))
            {
                return false;
            }
            arr = new string[] { imgDirPath, cssDirPath, jsDirPath, flashDirPath };
            drive = Directory.GetDirectoryRoot(htmlDirPath);
            foreach (string path in arr)
            {
                if (Directory.GetDirectoryRoot(path) != drive)
                {
                    return false;
                }
            }
            return true;
        }

        /// <summary>
        /// 规范好所有路径配置
        /// </summary>
        public void StrictPath()
        {
            this.htmlDirPath = Path.GetFullPath(this.htmlDirPath.TrimEnd('\\'));
            this.imgDirPath = Path.GetFullPath(this.imgDirPath.TrimEnd('\\'));
            this.jsDirPath = Path.GetFullPath(this.jsDirPath.TrimEnd('\\'));
            this.cssDirPath = Path.GetFullPath(this.cssDirPath.TrimEnd('\\'));
            this.flashDirPath = Path.GetFullPath(this.flashDirPath.TrimEnd('\\'));
        }

        /// <summary>
        /// 判断指定的目录是否存在，不存在则创建
        /// </summary>
        public void CreateDir()
        {
            //创建css目录
            if (!Directory.Exists(this.cssDirPath))
            {
                Directory.CreateDirectory(this.cssDirPath);
            }
            //创建JS目录
            if (!Directory.Exists(this.jsDirPath))
            {
                Directory.CreateDirectory(this.jsDirPath);
            }
            //创建Flash目录
            if (!Directory.Exists(this.flashDirPath))
            {
                Directory.CreateDirectory(this.flashDirPath);
            }
            //创建图片目录
            if (!Directory.Exists(this.imgDirPath))
            {
                Directory.CreateDirectory(this.imgDirPath);
            }
        }
    }
}