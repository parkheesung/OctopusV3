using OctopusV3.Core;
using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace OctopusV3.API.Google
{
    public class FCM_Client : IDisposable
    {
        private bool disposedValue;

        public string ServerKey { get; set; } = string.Empty;

        public async Task<ReturnValue> sendMessage(string title, string msg, string instanceIdToken)
        {
            var result = new ReturnValue();


            try
            {
                //1. 전송정보 생성
                string serverKey = $"key={ServerKey}";
                string url = "https://fcm.googleapis.com/fcm/send";
                string postJson = (@"{
                            'content_available': false,
                            'data':
                            {
                                'title': '" + HttpUtility.UrlEncode(title) + @"',
                                'body': '" + HttpUtility.UrlEncode(msg) + @"',
                                'icon': '',
                            },
                            'to': '" + instanceIdToken + @"'
                        }")
                                    .Replace("'", "\"")
                                    .Trim();

                //2. Firebase 서버에 REST 전송
                using (HttpClient client = new HttpClient() { BaseAddress = new Uri(url) })
                {
                    //1) 요청
                    client.DefaultRequestHeaders.TryAddWithoutValidation("Authorization", serverKey);
                    StringContent postEncoded = new StringContent(postJson.Replace("\t", "").Replace("\r\n", ""), Encoding.UTF8, "application/json");
                    HttpResponseMessage httpResponse = await client.PostAsync("", postEncoded);

                    //2) 응답분석
                    string responseText = await httpResponse.Content.ReadAsStringAsync();
                    if (httpResponse.IsSuccessStatusCode)
                    {
                        result.Success(1);
                    }
                    else
                    {
                        result.Error(responseText);
                    }
                }
            }
            catch (Exception ex)
            {
                result.Error(ex);
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

        ~FCM_Client()
        {
            Dispose(disposing: false);
        }

        public void Dispose()
        {
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
    }
}
