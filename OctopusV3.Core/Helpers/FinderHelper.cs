using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace OctopusV3.Core
{
    public class FinderHelper
    {

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

        public static List<long> ConvertLong(string arrStr)
        {
            Regex reg = new Regex("[0-9]{1,20}");
            List<long> list = new List<long>();
            if (arrStr != null && !String.IsNullOrWhiteSpace(arrStr))
            {
                string[] chk = arrStr.Split(',');
                if (chk != null && chk.Length > 0)
                {
                    foreach (string chkValue in chk)
                    {
                        if (reg.IsMatch(chkValue))
                        {
                            list.Add(Convert.ToInt64(chkValue));
                        }
                    }
                }
            }
            return list;
        }
    }

    public static class ExtendFinderHelper
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

        public static bool IsContain(this List<long> list, long target)
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
