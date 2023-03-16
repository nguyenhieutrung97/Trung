using AzureJWT.Constants;
using AzureJWT.Models;
using Newtonsoft.Json;

namespace AzureJWT.Services
{
    internal static class JWTService
    {
        internal static async Task<string> GetJWTTokenAsync(HttpClient client)
        {
            var values = new Dictionary<string, string>
              {
                  { "client_id", AzureDetails.ClientID },
                  { "scope", "https://graph.microsoft.com/.default" },
                  { "grant_type", "client_credentials" },
                  { "client_secret", AzureDetails.ClientSecret }
              };

            var content = new FormUrlEncodedContent(values);

            var response = await client.PostAsync($"https://login.microsoftonline.com/{AzureDetails.TenantID}/oauth2/v2.0/token", content);

            var responseString = await response.Content.ReadAsStringAsync();

            var result = JsonConvert.DeserializeObject<JWTTokenResponse>(responseString);

            return result.access_token;
        }
    }

}
