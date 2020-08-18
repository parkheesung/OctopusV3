using OctopusV3.Core;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace OctopusV3.API
{
    public class NewsApiHelper : ApiHelperBase, IDisposable
    {
        private bool disposedValue;

        public ILogHelper Logger { get; set; }

        protected string ApiKey { get; set; } = string.Empty;

        public NewsApiHelper() : base()
        {
            this.ApplicationName = "NewsAPI";
        }

        public NewsApiHelper(string apikey) : base()
        {
            this.ApplicationName = "NewsAPI";
            this.ApiKey = apikey;
        }

        public NewsData GetHeadlines(string Country)
        {
            NewsData result = new NewsData();

            try
            {
                StringBuilder url = new StringBuilder(255);
                url.Append("http://newsapi.org/v2/top-headlines?");
                url.Append($"country={Country}");
                url.Append($"&apiKey={this.ApiKey}");

                using (var wc = new WebClient())
                {
                    wc.Encoding = Encoding.UTF8;
                    string tmp = wc.DownloadString(url.ToString());
                    if (!string.IsNullOrWhiteSpace(tmp))
                    {
                        if (this.Logger != null)
                        {
                            this.Logger.Debug(tmp);
                        }
                        result = this.Deserialize<NewsData>(tmp);
                    }
                }
            }
            catch (Exception ex)
            {
                if (this.Logger != null)
                {
                    this.Logger.Error(ex);
                }
            }

            return result;
        }

        public NewsData GetQuestion(string Query, string fromDate)
        {
            NewsData result = new NewsData();

            try
            {
                StringBuilder url = new StringBuilder(255);
                url.Append("http://newsapi.org/v2/everything?");
                url.Append($"q={Query}");
                url.Append($"&from={fromDate}");
                url.Append("&sortBy=popularity");
                url.Append($"&apiKey={this.ApiKey}");

                using (var wc = new WebClient())
                {
                    wc.Encoding = Encoding.UTF8;
                    string tmp = wc.DownloadString(url.ToString());
                    if (!string.IsNullOrWhiteSpace(tmp))
                    {
                        result = this.Deserialize<NewsData>(tmp);
                    }
                }
            }
            catch (Exception ex)
            {
                if (this.Logger != null)
                {
                    this.Logger.Error(ex);
                }
            }

            return result;
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                }

                disposedValue = true;
            }
        }

        ~NewsApiHelper()
        {
            Dispose(disposing: false);
        }

        public void Dispose()
        {
            Dispose(disposing: true);
            //GC.SuppressFinalize(this);
        }
    }
}
