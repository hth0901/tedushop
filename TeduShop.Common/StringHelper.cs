using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace TeduShop.Common
{
    public class StringHelper
    {
        public static string ToUnsignString(string strInput)
        {
            strInput = strInput.Trim();
            for (int i = 0x20; i < 0x30; i++)
            {
                strInput = strInput.Replace(((char)i).ToString(), " ");
            }
            strInput = strInput.Replace(".", "-");
            strInput = strInput.Replace(" ", "-");
            strInput = strInput.Replace(",", "-");
            strInput = strInput.Replace(";", "-");
            strInput = strInput.Replace(":", "-");
            strInput = strInput.Replace("  ", "-");
            Regex regex = new Regex(@"\p{IsCombiningDiacriticalMarks}+");
            string str = strInput.Normalize(NormalizationForm.FormD);
            string str2 = regex.Replace(str, string.Empty).Replace('đ', 'd').Replace('Đ', 'D');
            while (str2.IndexOf("?") >= 0)
            {
                str2 = str2.Remove(str2.IndexOf("?"), 1);
            }
            while (str2.Contains("--"))
            {
                str2 = str2.Replace("--", "-").ToLower();
            }
            return str2;
        }
    }
}
