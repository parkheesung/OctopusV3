using System.IO;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace OctopusV3.Net.Mvc
{
    public class DynamicResult : FileResult
    {

        public Encoding encType { get; set; } = Encoding.UTF8;

        public string Content { get; set; } = string.Empty;

        public DynamicResult() : base("text/html")
        {
        }

        protected override void WriteFile(HttpResponseBase response)
        {
            Stream outputStream = response.OutputStream;
            byte[] byteArray = this.encType.GetBytes(Content);
            response.HeaderEncoding = this.encType;
            response.ContentEncoding = this.encType;
            response.OutputStream.Write(byteArray, 0, byteArray.GetLength(0));
        }
    }
}
