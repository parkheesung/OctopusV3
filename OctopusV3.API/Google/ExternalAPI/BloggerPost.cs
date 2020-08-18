using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace OctopusV3.API.Google
{
    public class BloggerPost
    {
        public string kind { get; set; } = string.Empty;

        public string etag { get; set; } = string.Empty;

        public List<BloggerPostItem> items { get; set; } = new List<BloggerPostItem>();

        public BloggerPost() : base()
        {
        }
    }

    public class BloggerPostItem : BloggerAPIBase
    {
        public List<BloggerPostItemBlog> blog { get; set; }

        public string title { get; set; } = string.Empty;

        public string content { get; set; } = string.Empty;

        public BloggerDataItem replies { get; set; } = new BloggerDataItem();

        public string[] labels { get; set; }

        public string etag { get; set; } = string.Empty;

        public string Thumbnail
        {
            get
            {
                string result = string.Empty;

                if (!string.IsNullOrWhiteSpace(this.content))
                {
                    foreach(Capture item in this.ExtractURL(this.content))
                    {
                        if (item.Value.ToLower().IndexOf(".jpg") > -1
                            || item.Value.ToLower().IndexOf(".png") > -1
                            || item.Value.ToLower().IndexOf(".gif") > -1)
                        {
                            result = item.Value;
                            break;
                        }
                    }
                }

                if (string.IsNullOrWhiteSpace(result))
                {
                    foreach (Capture item in this.ExtractURL(this.content))
                    {
                        result = item.Value;
                        break;
                    }
                }

                return result;
            }
        }

        public CaptureCollection ExtractURL(string source)
        {
            return Regex.Match(source, "src\\s*=\\s*\"(?<url>.*?)\"").Groups["url"].Captures;
        }

        public BloggerPostItem()
        {

        }
    }

    public class BloggerPostItemBlog
    {
        public string id { get; set; } = string.Empty;
    }

    public class BloggerPostItemAuth
    {
        public string id { get; set; } = string.Empty;
        public string displayName { get; set; } = string.Empty;
        public string url { get; set; } = string.Empty;

        public List<BloggerPostItemAuthImage> image { get; set; }
    }

    public class BloggerPostItemAuthImage
    {
        public string url { get; set; } = string.Empty;
    }
}

