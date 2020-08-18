using System;
using System.Collections.Generic;
using System.Text;

namespace OctopusV3.API
{
    public class NewsItemBase
    {
        public string publishedAt { get; set; } = string.Empty;

        public DateTime RegistDate
        {
            get
            {
                if (!string.IsNullOrWhiteSpace(publishedAt))
                {
                    if (publishedAt.IndexOf("T") > -1)
                    {
                        string date = publishedAt.Split('T')[0].Trim();
                        string time = publishedAt.Split('T')[1].Trim();
                        if (time.IndexOf("-") > -1)
                        {
                            time = time.Split('-')[0].Trim();
                        }

                        return Convert.ToDateTime($"{date} {time}");
                    }
                    else
                    {
                        return Convert.ToDateTime(publishedAt);
                    }
                }
                else
                {
                    return DateTime.Now;
                }
            }
        }


    }
}
