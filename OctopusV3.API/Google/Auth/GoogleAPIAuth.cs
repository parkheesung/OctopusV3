namespace OctopusV3.API.Google
{
    public class GoogleAPIAuth
    {
        public string ApiKey { get; set; } = string.Empty;
        public string ClientID { get; set; } = string.Empty;
        public string ClientPWD { get; set; } = string.Empty;

        public GoogleAPIAuth()
        {
        }

        public GoogleAPIAuth(string apikey)
        {
            this.ApiKey = apikey;
        }
    }
}
