using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security.Cryptography;

namespace Tools
{
    public static  class MyMD5
    {
        private static MD5 md5 = MD5.Create();
        
        public static string myMD5(string str)
        {
            byte[] buf = Encoding.Default.GetBytes(str);
            byte[] newBuf = md5.ComputeHash(buf);
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < newBuf.Length; i++)
            {
                sb.Append(newBuf[i].ToString("x2"));
            }
            string md5Pwd = sb.ToString();
            return md5Pwd;
        }
    }
}
