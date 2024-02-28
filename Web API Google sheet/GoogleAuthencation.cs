using Google.Apis.Auth.OAuth2;

namespace Web_API_Google_sheet
{
    public class GoogleAuthencation
    {
        public static UserCredential Login(string googleClientID , string googleClientSecret, string[] scopes)
        {
            ClientSecrets secrets = new ClientSecrets()
            {
                ClientId = googleClientID,
                ClientSecret = googleClientSecret,
            };

            return GoogleWebAuthorizationBroker.AuthorizeAsync(secrets, scopes, "user", CancellationToken.None).Result;
        }
    }
}
