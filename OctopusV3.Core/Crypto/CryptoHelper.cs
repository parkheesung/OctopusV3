namespace OctopusV3.Core
{
    public class CryptoHelper
    {
        public static CryptoBase64Helper Base64 { get; set; } = new CryptoBase64Helper();

        public static CryptoAES128Helper AES123 { get; set; } = new CryptoAES128Helper();

        public static CryptoAES256Helper AES256 { get; set; } = new CryptoAES256Helper();

        public static CryptoAESHelper AES { get; set; } = new CryptoAESHelper();

        public static CryptoSHA256Helper SHA256 { get; set; } = new CryptoSHA256Helper();

        public static CryptoSHA512Helper SHA512 { get; set; } = new CryptoSHA512Helper();

    }


}
