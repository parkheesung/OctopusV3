using Microsoft.AspNetCore.Http;
using System;

namespace OctopusV3.Core.Mvc
{
    public class CookieHelper
    {
        public CookieHelper()
        {
        }

        public static void CookieSet(string key, string value)
        {
            GlobalSite.Current.Response.Cookies.Append(key, value);
        }

        public static void CookieSet(string key, string value, DateTime expireDate)
        {
            CookieOptions option = new CookieOptions();
            option.Expires = expireDate;
            GlobalSite.Current.Response.Cookies.Append(key, value, option);
        }

        public static void CookieAdd(string key, string value)
        {
            GlobalSite.Current.Response.Cookies.Append(key, value);
        }

        public static void CookieAdd(string key, string value, DateTime expireDate)
        {
            CookieOptions option = new CookieOptions();
            option.Expires = expireDate;
            GlobalSite.Current.Response.Cookies.Append(key, value, option);
        }

        public static string CookieGet(string key)
        {
            return GlobalSite.Current.Request.Cookies[key];
        }

        public static bool CookieExists(string key)
        {
            string tmp = CookieGet(key);
            if (!string.IsNullOrWhiteSpace(tmp))
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
            GlobalSite.Current.Response.Cookies.Delete(key);
        }
    }
}
