using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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

        public static void CookieAdd(string key, string value)
        {
            StringBuilder builder = new StringBuilder(200);
            string tmp = CookieGet(key);
            builder.Append(tmp);
            if (!string.IsNullOrWhiteSpace(tmp))
            {
                builder.Append(",");
            }
            builder.Append(value);

            HttpContext.Current.Response.Cookies[key].Value = builder.ToString();
        }

        public static void CookieAdd(string key, string value, DateTime expireDate)
        {
            StringBuilder builder = new StringBuilder(200);
            string tmp = CookieGet(key);
            builder.Append(tmp);
            if (!string.IsNullOrWhiteSpace(tmp))
            {
                builder.Append(",");
            }
            builder.Append(value);

            HttpContext.Current.Response.Cookies[key].Value = builder.ToString();
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

    }

}
