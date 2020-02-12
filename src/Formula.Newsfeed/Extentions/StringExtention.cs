using System;
using System.Text.RegularExpressions;

namespace Formula.Newsfeed.Extentions
{
    public static class StringExtension
    {
        public static string GetBetween(this string strSource, string strStart, string strEnd)
        {
            int Start, End;
            if (strSource.Contains(strStart) && strSource.Contains(strEnd))
            {
                Start = strSource.IndexOf(strStart, 0) + strStart.Length;
                End = strSource.IndexOf(strEnd, Start);
                return strSource.Substring(Start, End - Start);
            }
            else
                return "";
        }
        public static string RemoveHTML(this string input)
        {
            return Regex.Replace(input, "<.*?>", string.Empty);
        }
    }
}
