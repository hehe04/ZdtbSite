﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace ZdtbSite
{
    public static class CommonExtensions
    {
        public static string ToMd5String(this string str)
        {
            MD5CryptoServiceProvider hashmd5 = new MD5CryptoServiceProvider();
            return BitConverter.ToString(hashmd5.ComputeHash(Encoding.UTF8.GetBytes(str))).Replace("-", "").ToUpper();
        }

        public static string strSub(this string str, int startIndex, int endIndex, string paddingStr)
        {
            string resStr = str;
            if (endIndex - startIndex < str.Length) resStr = str.Substring(startIndex, endIndex);
            if (!string.IsNullOrEmpty(paddingStr)) resStr += paddingStr;
            return resStr;
        }
    }
}
