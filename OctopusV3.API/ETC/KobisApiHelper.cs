using OctopusV3.Core;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace OctopusV3.API
{
    public class KobisApiHelper : ApiHelperBase, IDisposable
    {
        public string Key { get; set; } = string.Empty;

        public ILogHelper Logger { get; set; }

        public KobisApiHelper() : base()
        {
            this.ApplicationName = "영화관입장권통합전산망 오픈API";
        }

        public KobisApiHelper(string key) : base()
        {
            this.ApplicationName = "영화관입장권통합전산망 오픈API";
            this.Key = key;
        }

        public KobisRankMovie GetWeeklyRank(DateTime Dt)
        {
            KobisRankMovie result = new KobisRankMovie();

            try
            {
                StringBuilder url = new StringBuilder(255);
                url.Append("http://www.kobis.or.kr/kobisopenapi/webservice/rest/boxoffice/searchWeeklyBoxOfficeList.json");
                url.Append($"?key={this.Key}");
                url.Append($"&targetDt={Dt.ToString("yyyyMMdd")}");

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
                        result = this.Deserialize<KobisRankMovie>(tmp);
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

        public KobisRankMovie GetDailyRank(DateTime Dt)
        {
            KobisRankMovie result = new KobisRankMovie();

            try
            {
                StringBuilder url = new StringBuilder(255);
                url.Append("http://www.kobis.or.kr/kobisopenapi/webservice/rest/boxoffice/searchDailyBoxOfficeList.json");
                url.Append($"?key={this.Key}");
                url.Append($"&targetDt={Dt.ToString("yyyyMMdd")}");

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
                        result = this.Deserialize<KobisRankMovie>(tmp);
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

        public KobisMovieInfo GetDailyRank(string movieCd)
        {
            KobisMovieInfo result = new KobisMovieInfo();

            try
            {
                StringBuilder url = new StringBuilder(255);
                url.Append("http://www.kobis.or.kr/kobisopenapi/webservice/rest/movie/searchMovieInfo.json");
                url.Append($"?key={this.Key}");
                url.Append($"&movieCd={movieCd}");

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
                        result = this.Deserialize<KobisMovieInfo>(tmp);
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

        public void Dispose()
        {
        }
    }
}
