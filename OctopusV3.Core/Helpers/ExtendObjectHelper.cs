using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace OctopusV3.Core
{
    public static class ExtendObjectHelper
    {
        public static List<int> ToIntegerList(this string str)
        {
            var result = new List<int>();
            Regex reg = new Regex("[0-9]{1,60}");

            if (!string.IsNullOrWhiteSpace(str))
            {
                if (str.IndexOf(",") > -1)
                {
                    string[] tmp = str.Split(',');
                    foreach(string t in tmp)
                    {
                        if (reg.IsMatch(t))
                        {
                            result.Add(Convert.ToInt32(t));
                        }
                    }
                }
                else
                {
                    if (reg.IsMatch(str))
                    {
                        result.Add(Convert.ToInt32(str));
                    }
                }
            }

            return result;
        }
    }
}
