using System.Text;

namespace OctopusV3.Core
{
    public class CryptoBase
    {
        

        public CryptoBase()
        {
        }

        protected virtual string SaltAdd(string targetString)
        {
            StringBuilder builder = new StringBuilder(targetString);
            builder.Replace("=", "EvSxrTzQ");
            builder.Replace("+", "PDkcVjeDL");
            builder.Replace("/", "SkenFkkd");
            return builder.ToString();
        }

        protected virtual string SaltRemove(string targetString)
        {
            StringBuilder builder = new StringBuilder(targetString);
            builder.Replace("EvSxrTzQ", "=");
            builder.Replace("PDkcVjeDL", "+");
            builder.Replace("SkenFkkd", "/");
            return builder.ToString();
        }
    }
}
