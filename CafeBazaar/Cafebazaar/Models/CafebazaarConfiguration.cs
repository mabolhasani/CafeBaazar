namespace Cafebazaar.Models
{
    public class CafebazaarConfiguration
    {
        public string ClientId { get; }

        public string ClientSecret { get; }

        public string PackageName { get; }

        public string RefreshToken { get; }

        public CafebazaarConfiguration(string clientId,string clientSecret, string packageName,string refreshToken)
        {
            ClientId = clientId;
            ClientSecret = clientSecret;
            PackageName = packageName;
            RefreshToken = refreshToken;
        }
    }
}
