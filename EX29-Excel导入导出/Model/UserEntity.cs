﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    /// <summary>
    /// 用户实体类
    /// </summary>
	public class UserEntity
	{
        /// <summary>
        /// .Ctor
        /// </summary>
        //public UserEntity()
        //{
        //    _transcriptsEn = new TranscriptsEntity();
        //}

        private string name;

        /// <summary>
        /// 姓名---转换为第一列
        /// </summary>
        public string Name
        {
            get { return name; }
            set { name = value; }
        }



        private string age;

        /// <summary>
        /// 年龄---转换为第2列
        /// </summary>
        public string  Age
        {
            get { return age; }
            set { age = value; }
        }



        private string gender;

        /// <summary>
        /// 性别 ---转换为第三列
       
  
        /// </summary>
        public string Gender
        {
            get { return gender; }
            set { gender = value; }
        }

        /// <summary>
        /// 性别的中文意思
        /// <para>输出：男、女、保命</para>
        /// </summary>
        //public string GenderName
        //{
        //    get
        //    { 
        //        string rs="保密";
        //        if (Gender == "Male")
        //        {
        //            rs = "男";
        //        }
        //        else if (Gender == "Female")
        //        {
        //            rs = "女";
        //        }
        //        return rs;
        //    }
        //    set
        //    {
        //        if (value == "男")
        //        {
        //            Gender = "Male";
        //        }
        //        else if (value == "女")
        //        {
        //            Gender = "Female";
        //        }
        //        else
        //        {
        //            Gender = "unkonw";
        //        }
        //    }
        //}

        //private TranscriptsEntity _transcriptsEn;

        ///// <summary>
        ///// 成绩单子类
        ///// </summary>
        //public TranscriptsEntity TranscriptsEn
        //{
        //    get { return _transcriptsEn; }
        //    set { _transcriptsEn = value; }
        //}

        //private bool _isExcelVaildateOK = true;

        ///// <summary>
        ///// Excel验证是否通过，默认为true
        ///// <para>true：通过；false：不通过</para>
        ///// </summary>
        //public bool IsExcelVaildateOK
        //{
        //    get { return _isExcelVaildateOK; }
        //    set { _isExcelVaildateOK = value; }
        //}
	}
}
