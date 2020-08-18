using OctopusV3.Core;
using System.Text;

namespace OctopusV3.API
{
    public class Papago
    {
        public string text { get; set; } = string.Empty;

        public string Result { get; set; } = string.Empty;

        public Language RequestLanguage { get; set; }

        public Language ResponseLanguage { get; set; }

        public const string RootURL = "papago.naver.com";

        public enum Language
        {
            [StringValue("ko")]
            Korean,
            [StringValue("en")]
            English
        }


        public Papago()
        {
        }

        public static Papago EnglishToKorean(string text)
        {
            return new Papago()
            {
                text = text,
                RequestLanguage = Language.English,
                ResponseLanguage = Language.Korean
            };
        }

        public static Papago KoreanToEnglish(string text)
        {
            return new Papago()
            {
                text = text,
                RequestLanguage = Language.Korean,
                ResponseLanguage = Language.English
            };
        }
    }

    public static class ExtendPapago
    {
        public static string CreateURL(this Papago papago)
        {
            StringBuilder builder = new StringBuilder(255);
            builder.Append($"https://{Papago.RootURL}/");
            builder.Append($"?sk={papago.RequestLanguage.GetStringValue()}");
            builder.Append($"&tk={papago.ResponseLanguage.GetStringValue()}");
            builder.Append($"&st={papago.text.Trim()}");
            return builder.ToString();
        }
    }
}
