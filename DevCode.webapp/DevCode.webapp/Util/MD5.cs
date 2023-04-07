using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;

namespace DevCode.webapp.Util
{
    public class MD5
    {
        public static string GerarHashMd5(string input)
        {
            System.Security.Cryptography.MD5 md5Hash = System.Security.Cryptography.MD5.Create();

            byte[] data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(input));

            StringBuilder sBuilder = new StringBuilder();
            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }

            return sBuilder.ToString();
        }
    }
}