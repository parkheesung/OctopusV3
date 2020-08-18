using System;

namespace OctopusV3.API.Google
{
    public abstract class BloggerAPIBase
    {
        public string id { get; set; } = string.Empty;

        public string kind { get; set; } = string.Empty;

        public string published { get; set; } = string.Empty;

        public string updated { get; set; } = string.Empty;

        public DateTime RegistDate
        {
            get
            {
                if (!string.IsNullOrWhiteSpace(published))
                {
                    if (published.IndexOf("T") > -1)
                    {
                        string date = published.Split('T')[0].Trim();
                        string time = published.Split('T')[1].Trim();
                        if (time.IndexOf("-") > -1)
                        {
                            time = time.Split('-')[0].Trim();
                        }

                        return Convert.ToDateTime($"{date} {time}");
                    }
                    else
                    {
                        return Convert.ToDateTime(published);
                    }
                }
                else
                {
                    return DateTime.Now;
                }
            }
        }

        public DateTime UpdateDate
        {
            get
            {
                if (!string.IsNullOrWhiteSpace(updated))
                {
                    if (updated.IndexOf("T") > -1)
                    {
                        string date = updated.Split('T')[0].Trim();
                        string time = updated.Split('T')[1].Trim();
                        if (time.IndexOf("-") > -1)
                        {
                            time = time.Split('-')[0].Trim();
                        }

                        return Convert.ToDateTime($"{date} {time}");
                    }
                    else
                    {
                        return Convert.ToDateTime(updated);
                    }
                }
                else
                {
                    return DateTime.Now;
                }
            }
        }

        public string url { get; set; } = string.Empty;

        public string selfLink { get; set; } = string.Empty;

        public BloggerAPIBase()
        {
        }
    }

    public class BloggerDataItem
    {
        public int totalItems { get; set; } = 0;
        public string selfLink { get; set; } = string.Empty;

        public BloggerDataItem()
        {

        }
    }
}
