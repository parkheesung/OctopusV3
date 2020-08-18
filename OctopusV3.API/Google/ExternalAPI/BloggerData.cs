namespace OctopusV3.API.Google
{
    public class BloggerData : BloggerAPIBase
    {
        

        public string name { get; set; } = string.Empty;

        public string description { get; set; } = string.Empty;



        public BloggerDataItem posts { get; set; }

        public BloggerDataItem pages { get; set; }

        public BloggerDataLocale locale { get; set; }

        public BloggerData() : base()
        {
        }
    }

    public class BloggerDataLocale
    {
        public string language { get; set; } = string.Empty;

        public string country { get; set; } = string.Empty;

        public string variant { get; set; } = string.Empty;
    }
}

