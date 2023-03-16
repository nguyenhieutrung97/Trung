using AzureJWT.Constants;
using AzureJWT.Models;
using System.Collections.Generic;
using System.Net.Http.Headers;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace AzureJWT.Services
{
    internal static class MicrosoftGraphService
    {
        static string rootPath = "https://graph.microsoft.com/v1.0";
        internal static HttpClient AddBearTokenForRequest(HttpClient client, string token)
        {
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

            return client;
        }
        internal static async Task<IEnumerable<PrincipalItem>> GetListUsersInApp(HttpClient client)
        {

            var response = await client.GetAsync($"{rootPath}/servicePrincipals(appId='{AzureDetails.ClientID}')/appRoleAssignedTo");

            var responseString = await response.Content.ReadAsStringAsync();

            var result = JsonConvert.DeserializeObject<ServicePrincipalResponse<PrincipalItem>>(responseString);

            return result.Value;
        }

        internal static async Task<IEnumerable<AppRole>> GetListAppRolesInApp(HttpClient client)
        {

            var response = await client.GetAsync($"{rootPath}/servicePrincipals(appId='{AzureDetails.ClientID}')/appRoles");

            var responseString = await response.Content.ReadAsStringAsync();

            var result = JsonConvert.DeserializeObject<ServicePrincipalResponse<AppRole>>(responseString);

            return result.Value;
        }

        internal static async Task<IEnumerable<Member>> GetListMemberInGroup(HttpClient client, string groupId)
        {

            var response = await client.GetAsync($"{rootPath}/groups/{groupId}/members");

            var responseString = await response.Content.ReadAsStringAsync();

            var result = JsonConvert.DeserializeObject<ServicePrincipalResponse<Member>>(responseString);

            return result.Value;
        }
    }
}
