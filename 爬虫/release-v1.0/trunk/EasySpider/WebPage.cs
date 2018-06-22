﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using EasySpider.Utility;
using System.IO;
using System.Threading;

namespace EasySpider
{
    /// <summary>
    /// HTML内容封装类，提供页面内容处理的相关方法
    /// </summary>
    public class WebPage
    {
        private string pageUrl;
        private string html;
        private Encoding encode;

        /// <summary>
        /// 页面的完整html文本
        /// </summary>
        public string Html
        {
            get { return html; }
            set { html = value; }
        }

        /// <summary>
        /// 页面的Url，保存文件时使用
        /// </summary>
        public string PageUrl
        {
            get { return pageUrl; }
            set { pageUrl = value; }
        }

        /// <summary>
        /// html的编码，保存文件时使用
        /// </summary>
        public Encoding Encode
        {
            get { return encode; }
            set { encode = value; }
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="html">一段完整的html文本</param>        
        public WebPage(string html)
            : this(html, null, null)
        {
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="html">一段完整的html文本</param>
        /// <param name="url">页面的Url</param>
        /// <param name="encode">页面内容的编码格式</param>
        public WebPage(string html, string url, Encoding encode)
        {
            this.html = html;
            this.pageUrl = url;
            this.encode = encode;
        }

        #region 一些获取页面信息的相关公用实例方法
        /// <summary>
        /// 获取一个页面里所有href
        /// </summary>
        /// <returns>返回一个href组成的字符串数组，如果未找到则返回一个空数组</returns>
        public string[] GetAllHref()
        {
            MatchCollection matches = RegOpration.SearchByRegex(this.html, RegexCollection.RegHref);
            string[] hrefArray = new string[matches.Count];
            int index = 0;
            foreach (Match item in matches)
            {
                hrefArray[index++] = item.Groups["href"].Value;
            }
            return hrefArray;
        }

        /// <summary>
        /// 根据一个html串，获取所有form提交的action
        /// </summary>
        /// <param name="html"></param>
        /// <returns></returns>
        public static string[] GetAllAction(string html)
        {
            List<string> arr = new List<string>(5);
            MatchCollection matches = RegexCollection.RegFormAction.Matches(html);
            string[] actionArray = new string[matches.Count];
            int index = 0;
            foreach (Match item in matches)
            {
                actionArray[index++] = item.Groups["action"].Value;
            }
            return actionArray;
        }

        /// <summary>
        /// 得到一个过滤掉html中的所有script的字符串
        /// </summary>
        /// <returns>返回过滤以后的html内容</returns>
        public string FilterScript()
        {
            return RegexCollection.RegScript.Replace(this.html, "", -1);
        }

        /// <summary>
        /// 获取当前页面的Title
        /// </summary>        
        /// <returns>返回当前页面的Title</returns>
        public string GetTitle()
        {
            return Regex.Match(this.html, "<title>((?!</title>).*)</title>", RegexOptions.IgnoreCase).Groups[1].Value;
        }

        /// <summary>
        /// 获取当前页面的Keywords
        /// </summary>
        /// <returns>返回当前页面的Keywords</returns>
        public string GetKeywords()
        {
            //获取keywords
            if (Regex.Match(this.html, "<\\s*meta\\s*name=\\s*['\"]keywords['\"]\\s*content=\\s*['\"]((?!/>).*)['\"]\\s*/?\\s*>", RegexOptions.IgnoreCase).Success)
            {
                return Regex.Match(this.html, "<\\s*meta\\s*name=\\s*['\"]keywords['\"]\\s*content=\\s*['\"]((?!/>).*)['\"]\\s*/?\\s*>", RegexOptions.IgnoreCase).Groups[1].Value;
            }
            else
            {
                return Regex.Match(this.html, "<\\s*meta\\s*content=\\s*['\"]((?!/>).*)['\"]\\s*name=\\s*['\"]keywords['\"]\\s*/?\\s*>", RegexOptions.IgnoreCase).Groups[1].Value;
            }
        }
        #endregion

        #region 一些下载资源相关的公用实例方法
        /// <summary>
        /// 将html内容中的所有src和href地址转为为绝对地址，然后使用指定编码和路径保存为html文件（使用此方法，需要指定当前页面的Url）
        /// </summary>
        /// <param name="filePath">文件路径</param>
        /// <param name="ignoreScript">保存的时候是否忽略Script标签，若为true，则忽略JS</param>        
        /// <returns>如果下载成功，返回文件的本地路径，否则返回null</returns>
        public string SaveHtml(string filePath, bool ignoreScript)
        {
            string htmlContent = this.html;
            if (string.IsNullOrEmpty(pageUrl))
            {
                throw new SpiderException("未指定当前url");
            }
            //如果忽略JS
            if (ignoreScript)
            {
                htmlContent = this.FilterScript();
            }
            //将所有的href转换为绝对路径
            htmlContent = RegexCollection.RegHref.Replace(htmlContent, (mat) =>
            {
                return "href=\"" + PathUtility.ConvertToAbsoluteHref(this.pageUrl, mat.Groups["href"].Value) + "\"";
            });
            //将所有的src转换为绝对路径
            htmlContent = RegexCollection.RegSrc.Replace(htmlContent, (mat) =>
            {
                return "src=\"" + PathUtility.ConvertToAbsoluteHref(this.pageUrl, mat.Groups["src"].Value) + "\"";
            });
            return FileUtility.SaveText(filePath, htmlContent, this.encode);
        }

        /// <summary>
        ///使用同步方式下载，将html内容保存为html文件，并将html内容中引用的图片，css，js，flash都保存到本地，然后将html内容中引用的地址都转换为相对地址
        /// </summary>
        /// <param name="fileName">保存的文件名</param>                
        /// <param name="ignoreScript">保存的时候是否忽略Script标签，若为true，则忽略JS</param>
        /// <param name="dirConfig">页面下载文件夹相关配置信息</param>  
        /// <returns>如果下载成功，返回文件的本地路径，否则返回null</returns>
        public string SaveHtmlAndResource(string fileName, bool ignoreScript, DirConfig dirConfig)
        {
            string htmlContent = this.html;
            if (!dirConfig.CheckLegal())
            {
                throw new SpiderException("路径配置不在统一磁盘下");
            }
            dirConfig.CreateDir();
            if (string.IsNullOrEmpty(this.pageUrl))
            {
                throw new SpiderException("未指定当前url");
            }
            //如果忽略JS
            if (ignoreScript)
            {
                htmlContent = this.FilterScript();
            }
            #region 保存所有css和css中引用的图片
            htmlContent = RegexCollection.RegCssLink.Replace(htmlContent, delegate(Match match)
            {
                //由于css文件里有可能引用图片，所以在此处需要自定义css文件下载函数，将css文件中的图片下载到本地然后替换css文件中的引用路径
                return this.MatchUrl(match, this.pageUrl, dirConfig.HtmlDirPath, dirConfig.JsDirPath, "src", null, delegate(string cssUrl)
                {
                    //css内容
                    string cssContent, localPath = cssUrl;
                    CHttpWebRequest cRequest;
                    CHttpWebResponse cResponse;
                    //请求css文件
                    cRequest = Spider.CreateRequest(cssUrl);
                    cRequest.SetHeader("Referer", this.pageUrl);
                    cResponse = Spider.Get(cRequest);
                    //如果请求成功
                    if (cResponse.Success)
                    {
                        using (cResponse)
                        {
                            //获取css内容
                            cssContent = cResponse.GetContent(null, false);
                            //下载css里引用的图片，并替换css内容中图片地址的引用
                            cssContent = this.ReplaceBackgroundUrl(cssContent, cssUrl, dirConfig.CssDirPath, dirConfig.ImgDirPath, false, null);
                            //将css保存到本地
                            localPath = FileUtility.SaveText(Path.GetFullPath(dirConfig.CssDirPath + "\\" + cResponse.GetFileName()), cssContent, cResponse.GetEncoding());
                        }
                    }
                    //返回保存以后的css本地路径
                    return localPath;
                });
            });
            #endregion

            #region 保存所有JS
            htmlContent = RegexCollection.RegScriptLink.Replace(htmlContent, delegate(Match match)
            {
                return this.MatchUrl(match, this.pageUrl, dirConfig.HtmlDirPath, dirConfig.JsDirPath, "src", null, null);
            });
            #endregion

            #region 保存所有图片
            htmlContent = RegexCollection.RegImg.Replace(htmlContent, delegate(Match match)
            {
                return this.MatchUrl(match, this.pageUrl, dirConfig.HtmlDirPath, dirConfig.ImgDirPath, "src", null, null);
            });
            #endregion

            #region 保存所有Flash
            htmlContent = RegexCollection.RegFlash.Replace(htmlContent, delegate(Match match)
            {
                return this.MatchUrl(match, this.pageUrl, dirConfig.HtmlDirPath, dirConfig.FlashDirPath, "src", null, null);
            });
            #endregion

            #region 当前页面内嵌css中的图片
            htmlContent = this.ReplaceBackgroundUrl(htmlContent, this.PageUrl, dirConfig.HtmlDirPath, dirConfig.ImgDirPath, false, null);
            #endregion
            return FileUtility.SaveText(Path.GetFullPath(dirConfig.HtmlDirPath + "\\" + fileName), htmlContent, this.encode);
        }

        /// <summary>
        ///使用异步方式下载，将html内容保存为html文件，并将html内容中引用的图片，css，js，flash都保存到本地，然后将html内容中引用的地址都转换为相对地址
        /// </summary>
        /// <param name="fileName">保存的文件名</param>                
        /// <param name="ignoreScript">保存的时候是否忽略Script标签，若为true，则忽略JS</param>
        /// <param name="dirConfig">页面下载文件夹相关配置信息</param>  
        /// <returns>如果下载成功，返回文件的本地路径，否则返回null</returns>
        public string AsyncSaveHtmlAndResource(string fileName, bool ignoreScript, DirConfig dirConfig)
        {
            //当前的html内容
            string htmlContent = this.html;
            //一个字典，key是资源地址的在html中的占位符，value是资源下载到本地的路径（如果未下载成功则是资源的url）
            Dictionary<string, string> dic = new Dictionary<string, string>(200);
            if (!dirConfig.CheckLegal())
            {
                throw new SpiderException("路径配置不在统一磁盘下");
            }
            dirConfig.CreateDir();
            if (string.IsNullOrEmpty(this.pageUrl))
            {
                throw new SpiderException("未指定当前url");
            }
            //如果忽略JS
            if (ignoreScript)
            {
                htmlContent = this.FilterScript();
            }
            #region 保存所有css和css中引用的图片
            htmlContent = RegexCollection.RegCssLink.Replace(htmlContent, delegate(Match match)
            {
                //由于css文件里有可能引用图片，所以在此处需要自定义css文件下载函数，将css文件中的图片下载到本地然后替换css文件中的引用路径
                return this.MatchUrl(match, this.pageUrl, dirConfig.HtmlDirPath, dirConfig.JsDirPath, "src", null, delegate(string url)
                {
                    //css引用在html中的占位符
                    string placeHolder = this.GetPlaceHolder();
                    //css文件在本地的目录
                    string filePath;
                    //异步下载css文件中引用图片需要的字典
                    Dictionary<string, string> dicPlaceCss = new Dictionary<string, string>(20);
                    CHttpWebRequest cRequest;
                    //请求css文件
                    cRequest = Spider.CreateRequest(url);
                    cRequest.SetHeader("Referer", this.pageUrl);
                    #region 异步下载css文件
                    Spider.AsyncGet(cRequest, delegate(CHttpWebResponse cResponse)
                    {
                        //css文件内容
                        string cssContent;
                        //如果下载成功
                        if (cResponse.Success)
                        {
                            using (cResponse)
                            {
                                //获取css内容
                                cssContent = cResponse.GetContent(null, false);
                                //异步下载css里引用的图片，并替换css内容中图片地址的引用
                                cssContent = this.ReplaceBackgroundUrl(cssContent, url, dirConfig.CssDirPath, dirConfig.ImgDirPath, true, dicPlaceCss);
                                //确定异步下载都已经下载完成,将css内容中的占位符替换为图片下载完成后对应的相对路径
                                cssContent = this.ReplacePlaceHolder(cssContent, dicPlaceCss);
                                //保存css文件，获取保存以后的本地路径
                                filePath = FileUtility.SaveText(Path.GetFullPath(dirConfig.CssDirPath + "\\" + cResponse.GetFileName()), cssContent, cResponse.GetEncoding());
                                //css中的图片都下载完成密且css文件也下载完成，此处设置占位符对应的引用路径
                                lock (dic)
                                {
                                    //将css文件本地路径转换为一个引用路径
                                    dic[placeHolder] = filePath == null ? url : PathUtility.GetRelativePath(dirConfig.HtmlDirPath, filePath);
                                }
                            }
                        }
                    });
                    #endregion
                    //返回占位符
                    return placeHolder;
                },true,dic);
            });
            #endregion

            #region 保存所有JS
            htmlContent = RegexCollection.RegScriptLink.Replace(htmlContent, delegate(Match match)
            {
                return this.MatchUrl(match, this.pageUrl, dirConfig.HtmlDirPath, dirConfig.JsDirPath, "src", null, null, true, dic);
            });
            #endregion

            #region 保存所有图片
            htmlContent = RegexCollection.RegImg.Replace(htmlContent, delegate(Match match)
            {
                return this.MatchUrl(match, this.pageUrl, dirConfig.HtmlDirPath, dirConfig.ImgDirPath, "src", null, null, true, dic);
            });
            #endregion

            #region 保存所有Flash
            htmlContent = RegexCollection.RegFlash.Replace(htmlContent, delegate(Match match)
            {
                return this.MatchUrl(match, this.pageUrl, dirConfig.HtmlDirPath, dirConfig.FlashDirPath, "src", null, null, true, dic);
            });
            #endregion

            #region 当前页面内嵌css中的图片
            htmlContent = this.ReplaceBackgroundUrl(htmlContent, this.PageUrl, dirConfig.HtmlDirPath, dirConfig.ImgDirPath, true, dic);
            #endregion
            //确定异步下载都已经下载完成,将html内容中的占位符替换为资源下载完成后对应的相对路径
            htmlContent = this.ReplacePlaceHolder(htmlContent, dic);
            return FileUtility.SaveText(Path.GetFullPath(dirConfig.HtmlDirPath + "\\" + fileName), htmlContent, this.encode);
        }
        #endregion

        #region 其他一些公用封装
        /// <summary>
        /// 替换将js、css、图片、flash等文件下载到本地后，调用此方法获取在页面中引用本地文件的路径
        /// </summary>
        /// <param name="match">匹配到的js、css、图片、flash等标签的正则实例</param>
        /// <param name="resourceUrl">当前html页面或者css文件的url。此url用于将其内容中的相对地址转换为绝对地址并下载</param>
        /// <param name="referenceDir">引用图片的文件所在目录（可能是html文件所在目录，也能是css文件所在目录）</param>
        /// <param name="saveDir">下载文件存放的目录</param>
        /// <param name="regGroupName">指定匹配url的正则分组的组名</param>
        /// <param name="urlHandle">指定对匹配url进行处理的函数回调</param>
        /// <param name="downloadHandle">指定自定义下载处理的函数回调，此回调返回下载文件的本地路径或者占位符</param>
        /// <returns>返回替换后的标签字符串</returns>
        internal string MatchUrl(Match match, string resourceUrl, string referenceDir, string saveDir, string regGroupName, MatchCallback urlHandle, MatchCallback downloadHandle)
        {
            return MatchUrl(match, resourceUrl, referenceDir, saveDir, regGroupName, urlHandle, downloadHandle, false, null);
        }

        /// <summary>
        /// 替换将js、css、图片、flash等文件下载到本地后，调用此方法获取在页面中引用本地文件的路径
        /// </summary>
        /// <param name="match">匹配到的js、css、图片、flash等标签的正则实例</param>
        /// <param name="resourceUrl">当前html页面或者css文件的url。此url用于将其内容中的相对地址转换为绝对地址并下载</param>
        /// <param name="referenceDir">引用图片的文件所在目录（可能是html文件所在目录，也能是css文件所在目录）</param>
        /// <param name="saveDir">下载文件存放的目录</param>
        /// <param name="regGroupName">指定匹配url的正则分组的组名</param>
        /// <param name="urlHandle">指定对匹配url(也就是href或者src)进行处理的函数回调，此回调主要对url进行一些处理（例如去引号等等）</param>
        /// <param name="downloadHandle">指定自定义下载处理的函数回调，此回调返回下载文件的本地路径或者占位符</param>
        /// <param name="async">是否异步下载</param>
        /// <param name="dic">记录异步下载信息的字典</param>
        /// <returns>返回替换后的标签字符串</returns>
        internal string MatchUrl(Match match, string resourceUrl, string referenceDir, string saveDir, string regGroupName, MatchCallback urlHandle, MatchCallback downloadHandle, bool async, Dictionary<string, string> dic)
        {
            //文件的地址（可能是相对也可能是绝对）、文件的绝对Url地址、以及保存到本地以后的本地路径
            string href, url, localPath = "";
            href = match.Groups[regGroupName].Value;
            if (null != urlHandle)
            {
                href = urlHandle(href);
            }
            url = PathUtility.ConvertToAbsoluteHref(resourceUrl ?? this.pageUrl, href);
            //如果使用异步下载
            if (async)
            {
                //如果未指定异步下载函数
                if (null == downloadHandle)
                {
                    localPath = this.GetPlaceHolder();
                    //开始异步下载资源
                    Spider.SaveResourceAsync(url, saveDir, new Action<string>(delegate(string filePath)
                    {
                        lock (dic)
                        {
                            dic[localPath] = null == filePath ? url : PathUtility.GetRelativePath(referenceDir, filePath);
                        }
                    }));
                }
                else
                {
                    localPath = downloadHandle(url);
                }
                if (!dic.ContainsKey(localPath))
                {
                    lock (dic)
                    {
                        dic.Add(localPath, null);
                    }
                }

            }//如果使用同步下载
            else
            {
                if (null == downloadHandle)
                {
                    //保存文件，如果成功，则返回文件保存后的本地路
                    localPath = Spider.SaveResource(url, saveDir);
                }
                else
                {
                    localPath = downloadHandle(url);
                }
                //如果保存失败，则引用绝对url地址
                if (string.IsNullOrEmpty(localPath))
                {
                    localPath = url;
                }
                else
                {
                    localPath = PathUtility.GetRelativePath(referenceDir, localPath);
                }
            }
            //使用localPath替换html内容中的引用路径
            return match.Value.Replace(href, localPath);
        }

        /// <summary>
        /// 操作一段html文本或者css文本，将其中使用样式background:url(...)指定的图片下载到本地，并更改路径
        /// </summary>
        /// <param name="content">一段html或者css文本</param>
        /// <param name="cssUrl">css文件的url，如果是内嵌css则此url为css所在页面的url</param>
        /// <param name="referenceDir">引用图片的文件所在目录（可能是html文件所在目录，也能是css文件所在目录）</param>
        /// <param name="saveDir">下载图片存放的目录</param>
        /// <param name="async">是否异步下载</param>
        /// <param name="dic">记录异步下载信息的字典</param>
        /// <returns>返回替换后的文本</returns>
        internal string ReplaceBackgroundUrl(string content, string cssUrl, string referenceDir, string saveDir, bool async, Dictionary<string, string> dic)
        {
            //将css里面引用的图片下载到本地，并且然后替换css里的图片引用路径
            content = RegexCollection.RegCssImgUrl.Replace(content, delegate(Match match)
            {
                return this.MatchUrl(match, cssUrl, referenceDir, saveDir, "src", delegate(string url)
                {
                    //获取css里面引用图片的绝对路径，同时干掉图片url开头和结尾的引号，以免造成悲剧图片不显示的问题（例如 style="background:url(&quot;xxx.jpg&quot;);" ,如果不干掉图片地址中的引号就会出问题）  
                    return Regex.Replace(url, @"^(&quot;|'|"")|(&quot;|""|')$", "");
                }, null, async, dic);
            });
            return content;
        }

        /// <summary>
        /// 获取一个随机占位符
        /// </summary>
        /// <returns>返回一个字符串</returns>
        internal string GetPlaceHolder()
        {
            return "{{Spider_" + Guid.NewGuid().ToString("N") + "_Spider}}";
        }

        /// <summary>
        /// 确认资源异步下载都已经下载完成，然后将内容中的占位符替换为引用路径
        /// </summary>
        /// <param name="content">存储异步下载信息的字典</param>
        /// <param name="dic">存储异步下载信息的字典</param>
        /// <returns>返回替换以后的字符串</returns>
        private string ReplacePlaceHolder(string content, Dictionary<string, string> dic)
        {
            bool uncompleted;
            //确定异步下载都已经下载完成
            while (true)
            {
                Thread.Sleep(1000);
                uncompleted = false;
                lock (dic)
                {
                    foreach (string key in dic.Keys)
                    {
                        if (null == dic[key])
                        {
                            uncompleted = true;
                            break;
                        }
                    }
                }
                if (!uncompleted)
                {
                    break;
                }
            }
            //将占位符替换为引用路径
            foreach (string key in dic.Keys)
            {
                content = content.Replace(key, dic[key]);
            }
            return content;
        }
        #endregion
    }
}
