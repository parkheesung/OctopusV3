using System;
using System.Collections.Generic;
using System.Text;

namespace OctopusV3.API
{
    public class NewsData
    {
        public string status { get; set; } = string.Empty;

        public int totalResults { get; set; } = 0;

        public List<NewsArticle> articles { get; set; } = new List<NewsArticle>();
    }

    public class NewsArticle : NewsItemBase
    {
        public NewsArticleSource source { get; set; }

        public string author { get; set; } = string.Empty;
        public string title { get; set; } = string.Empty;

        public string description { get; set; } = string.Empty;

        public string url { get; set; } = string.Empty;

        public string urlToImage { get; set; } = string.Empty;

        public string content { get; set; } = string.Empty;
    }

    public class NewsArticleSource
    {
        public string id { get; set; } = string.Empty;

        public string name { get; set; } = string.Empty;
    }
}
