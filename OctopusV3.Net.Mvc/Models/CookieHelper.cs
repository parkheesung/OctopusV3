using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;

namespace OctopusV3.Net.Mvc
{
    public class CookieHelper
    {
        public CookieHelper()
        {
        }

        public static void CookieSet(string key, string value)
        {
            HttpContext.Current.Response.Cookies[key].Value = value;
        }

        public static void CookieSet(string key, string value, DateTime expireDate)
        {
            HttpContext.Current.Response.Cookies[key].Value = value;
            HttpContext.Current.Response.Cookies[key].Expires = expireDate;
        }

        public static string CookieGet(string key)
        {
            string result = string.Empty;
            if (HttpContext.Current != null && HttpContext.Current.Request != null && HttpContext.Current.Request.Cookies[key] != null)
            {
                result = HttpContext.Current.Request.Cookies[key].Value;
            }
            return result;
        }

        public static bool CookieExists(string key)
        {
            if (HttpContext.Current.Request.Cookies[key] != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static void CookieRemove(string key)
        {
            if (HttpContext.Current.Request.Cookies[key] != null)
            {
                HttpContext.Current.Response.Cookies[key].Expires = DateTime.Now.AddDays(-1);
            }
        }

        public static List<int> ConvertInteger(string arrStr)
        {
            Regex reg = new Regex("[0-9]{1,20}");
            List<int> list = new List<int>();
            if (arrStr != null && !String.IsNullOrWhiteSpace(arrStr))
            {
                string[] chk = arrStr.Split(',');
                if (chk != null && chk.Length > 0)
                {
                    foreach (string chkValue in chk)
                    {
                        if (reg.IsMatch(chkValue))
                        {
                            list.Add(Convert.ToInt32(chkValue));
                        }
                    }
                }
            }
            return list;
        }
    }

    public static class ExtendCookieHelper
    {
        public static bool IsContain(this List<int> list, int target)
        {
            bool result = false;

            if (list != null && list.Count > 0)
            {
                result = list.Where(x => x == target).Count() > 0;
            }

            return result;
        }
    }
}
