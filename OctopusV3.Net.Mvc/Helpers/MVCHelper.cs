﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace OctopusV3.Net.Mvc
{
    public static class MVCHelper
    {
        /// <summary>
        /// 두값을 비교하여 참인 경우에만 returnHTML을 반환합니다.
        /// </summary>
        /// <param name="originalValue">원본</param>
        /// <param name="compareValue">비교대상</param>
        /// <param name="returnHTML">참일 경우 반환할 문자열</param>
        /// <returns></returns>
        public static MvcHtmlString ValueCompare(this string originalValue, string compareValue, string returnHTML)
        {
            string result = String.Empty;

            if (!String.IsNullOrEmpty(returnHTML) && !String.IsNullOrEmpty(originalValue) && !String.IsNullOrEmpty(compareValue))
            {
                if (originalValue.ToLower().Equals(compareValue.ToLower()))
                {
                    result = returnHTML;
                }
            }

            return MvcHtmlString.Create(result);
        }

        public static MvcHtmlString ValueCompare(this long originalValue, long compareValue, string returnHTML)
        {
            string result = String.Empty;

            if (originalValue == compareValue)
            {
                result = returnHTML;
            }

            return MvcHtmlString.Create(result);
        }

        /// <summary>
        /// 두값을 비교하여 참인 경우에만 returnHTML을 반환합니다.
        /// </summary>
        /// <param name="originalValue">원본</param>
        /// <param name="compareValue">비교대상</param>
        /// <param name="returnHTML">참일 경우 반환할 문자열</param>
        /// <returns></returns>
        public static MvcHtmlString ValueCompare(this int originalValue, int compareValue, string returnHTML)
        {
            string result = String.Empty;

            if (!String.IsNullOrEmpty(returnHTML))
            {
                if (originalValue == compareValue)
                {
                    result = returnHTML;
                }
            }

            return MvcHtmlString.Create(result);
        }

        /// <summary>
        /// 두값을 비교하여 참인 경우에만 returnHTML을 반환합니다.
        /// </summary>
        /// <param name="originalValue">원본</param>
        /// <param name="compareValue">비교대상</param>
        /// <param name="returnHTML">참일 경우 반환할 문자열</param>
        /// <returns></returns>
        public static MvcHtmlString ValueCompare(this string originalValue, int compareValue, string returnHTML)
        {
            string result = String.Empty;

            if (!String.IsNullOrEmpty(returnHTML) && !String.IsNullOrEmpty(originalValue))
            {
                if (originalValue.Equals(Convert.ToString(compareValue)))
                {
                    result = returnHTML;
                }
            }

            return MvcHtmlString.Create(result);
        }

        /// <summary>
        /// 두값을 비교하여 참인 경우에만 returnHTML을 반환합니다.
        /// </summary>
        /// <param name="originalValue">원본</param>
        /// <param name="compareValue">비교대상</param>
        /// <param name="returnHTML">참일 경우 반환할 문자열</param>
        /// <returns></returns>
        public static MvcHtmlString ValueCompare(this int originalValue, string compareValue, string returnHTML)
        {
            string result = String.Empty;

            try
            {
                if (!String.IsNullOrEmpty(returnHTML))
                {
                    Regex pattern = new Regex("[0-9]{1,50}");
                    Match matchResult = pattern.Match(compareValue);
                    if (matchResult.Success)
                    {
                        int tmp = Convert.ToInt32(compareValue);
                        if (originalValue == tmp)
                        {
                            result = returnHTML;
                        }
                    }
                }
            }
            catch
            {
                result = String.Empty;
            }

            return MvcHtmlString.Create(result);
        }

        public static MvcHtmlString ValueCompare(this int originalValue, int Max, int Min, string returnHTML)
        {
            string result = String.Empty;

            if (!String.IsNullOrEmpty(returnHTML))
            {
                if (originalValue <= Max && originalValue >= Min)
                {
                    result = returnHTML;
                }
            }

            return MvcHtmlString.Create(result);
        }

        public static MvcHtmlString ValueCompare(this int originalValue, bool CheckWhere, string returnHTML)
        {
            string result = String.Empty;

            if (!String.IsNullOrEmpty(returnHTML))
            {
                if (CheckWhere)
                {
                    result = returnHTML;
                }
            }

            return MvcHtmlString.Create(result);
        }

        public static MvcHtmlString ValueCompare(this bool originalValue, bool CheckWhere, string returnHTML)
        {
            string result = String.Empty;

            if (!String.IsNullOrEmpty(returnHTML))
            {
                if (originalValue == CheckWhere)
                {
                    result = returnHTML;
                }
            }

            return MvcHtmlString.Create(result);
        }

        public static MvcHtmlString ValueCompare(this int originalValue, int[] compareValue, string returnHTML)
        {
            string result = String.Empty;

            if (!String.IsNullOrEmpty(returnHTML))
            {
                if (compareValue != null && compareValue.Length > 0)
                {
                    for (int i = 0; i < compareValue.Length; i++)
                    {
                        if (compareValue[i] == originalValue)
                        {
                            result = returnHTML;
                            break;
                        }
                    }
                }
            }

            return MvcHtmlString.Create(result);
        }

        public static MvcHtmlString ValueContain(this string originalValue, string compareValue, string returnHTML)
        {
            string result = String.Empty;

            if (!String.IsNullOrEmpty(returnHTML))
            {
                if ((originalValue != null && originalValue.Length > 0) && (compareValue != null && compareValue.Length > 0))
                {
                    if (originalValue.IndexOf(compareValue) > -1)
                    {
                        result = returnHTML;
                    }
                }
            }

            return MvcHtmlString.Create(result);
        }

        public static MvcHtmlString ValueContain(this string originalValue, IEnumerable<string> list, string returnHTML)
        {
            string result = String.Empty;

            if (!string.IsNullOrWhiteSpace(originalValue))
            {
                if (list != null && list.Count() > 0)
                {
                    foreach (var tmp in list)
                    {
                        if (tmp.Equals(originalValue, StringComparison.OrdinalIgnoreCase))
                        {
                            result = returnHTML;
                            break;
                        }
                    }
                }
            }

            return MvcHtmlString.Create(result);
        }

        public static MvcHtmlString ValueCompare(this DateTime original, DateTime target, string rtnValue)
        {
            if (original.Year == target.Year && original.Month == target.Month && original.Day == target.Day)
            {
                return MvcHtmlString.Create(rtnValue);
            }
            else
            {
                return MvcHtmlString.Create("");
            }
        }

        /// <summary>
        /// 출력할 문자열안에 엔터값을 <br/>태그로 치환합니다.
        /// </summary>
        /// <param name="str">출력할 문자열</param>
        /// <returns></returns>
        public static MvcHtmlString toEnter(this string str)
        {
            string result = String.Empty;

            if (!String.IsNullOrEmpty(str))
            {
                result = str.Trim().Replace("\r\n", "<br />").Replace("\r", "<br />").Replace("\n", "<br />").Replace(Environment.NewLine, "<br />");
            }

            return MvcHtmlString.Create(result);
        }

        public static T FormBinding<T>(this HttpRequestBase request) where T : new()
        {
            T result = new T();

            if (request != null && request.Form.Count > 0)
            {
                Type type = result.GetType();
                PropertyInfo[] properties = type.GetProperties();
                foreach(PropertyInfo property in properties)
                {
                    if (request.Form[property.Name] != null)
                    {
                        try
                        {
                            if (request.Form[property.Name].ToString().Equals("true", StringComparison.OrdinalIgnoreCase))
                            {
                                property.SetValue(result, true);
                            }
                            else if (request.Form[property.Name].ToString().Equals("false", StringComparison.OrdinalIgnoreCase))
                            {
                                property.SetValue(result, false);
                            }
                            else
                            {
                                property.SetValue(result, Convert.ChangeType(request.Form[property.Name], property.PropertyType), null);
                            }
                        }
                        catch
                        {
                        }
                    }
                }
            }

            return result;
        }

        public static List<T> FormListBinding<T>(this HttpRequestBase request) where T : new()
        {
            List<T> result = new List<T>();
            T tmp = default(T);

            if (request != null && request.Form.Count > 0)
            {
                Type type = result.GetType();
                PropertyInfo[] properties = type.GetProperties();
                foreach(string key in request.Form.AllKeys)
                {
                    tmp = new T();
                    foreach (PropertyInfo property in properties)
                    {
                        if (request.Form[property.Name] != null)
                        {
                            try
                            {
                                if (request.Form[property.Name].ToString().Equals("true", StringComparison.OrdinalIgnoreCase))
                                {
                                    property.SetValue(tmp, true);
                                }
                                else if (request.Form[property.Name].ToString().Equals("false", StringComparison.OrdinalIgnoreCase))
                                {
                                    property.SetValue(tmp, false);
                                }
                                else
                                {
                                    property.SetValue(tmp, Convert.ChangeType(request.Form[property.Name], property.PropertyType), null);
                                }
                            }
                            catch
                            {
                            }

                            result.Add(tmp);
                        }
                    }
                }
            }

            return result;
        }

        public static T GetBinding<T>(this HttpRequestBase request) where T : new()
        {
            T result = new T();

            if (request != null && request.QueryString.Count > 0)
            {
                Type type = result.GetType();
                PropertyInfo[] properties = type.GetProperties();
                foreach (PropertyInfo property in properties)
                {
                    if (request.QueryString[property.Name] != null)
                    {
                        try
                        {
                            if (request.QueryString[property.Name].ToString().Equals("true", StringComparison.OrdinalIgnoreCase))
                            {
                                property.SetValue(result, true);
                            }
                            else if (request.QueryString[property.Name].ToString().Equals("false", StringComparison.OrdinalIgnoreCase))
                            {
                                property.SetValue(result, false);
                            }
                            else
                            {
                                property.SetValue(result, Convert.ChangeType(request.QueryString[property.Name], property.PropertyType), null);
                            }
                        }
                        catch
                        {

                        }
                    }
                }
            }

            return result;
        }
    }
}
