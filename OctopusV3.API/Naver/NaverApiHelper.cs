using OctopusV3.Core;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace OctopusV3.API
{
    public class NaverApiHelper : ApiHelperBase, IDisposable
    {
        public string Key { get; set; } = string.Empty;

        public ILogHelper Logger { get; set; }

        public NaverApiHelper() : base()
        {
            this.ApplicationName = "네이버 오픈API";
        }

        public NaverApiHelper(string key) : base()
        {
            this.ApplicationName = "네이버 오픈API";
            this.Key = key;
        }

        public void Dispose()
        {

        }

        public ReturnValues<Papago> Translation(Papago data, IWebClient wc)
        {
            var result = new ReturnValues<Papago>();

            if (string.IsNullOrWhiteSpace(data.text))
            {
                result.Error("번역 대상이 없습니다.");
            }
            else if (data.text.Trim().Length >= 5000)
            {
                result.Error("1회 번역 최대 문자열은 5000 글자 입니다.");
            }
            else
            {
                try
                {
                    string tmp = wc.DownloadString(data.CreateURL());
                    if (!string.IsNullOrWhiteSpace(tmp))
                    {
                        HtmlAgilityPack.HtmlDocument document = new HtmlAgilityPack.HtmlDocument();
                        document.LoadHtml(tmp);
                        HtmlAgilityPack.HtmlNode targetObject = document.GetElementbyId("txtTarget");
                        if (targetObject != null)
                        {
                            data.Result = targetObject.InnerText.Trim();
                            result.Success(1, data);
                        }
                        else
                        {
                            var nodes = document.DocumentNode.SelectSingleNode("//div[@id='txtTarget']");
                            if (nodes != null)
                            {
                                data.Result = nodes.InnerText.Trim();
                                result.Success(1, data);
                            }
                            else
                            {
                                result.Error("Not Found Target!!!!");
                                result.Value = tmp;
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    result.Error(ex);
                    if (this.Logger != null)
                    {
                        this.Logger.Error(ex);
                    }
                }
            }

            return result;
        }
    }
}
