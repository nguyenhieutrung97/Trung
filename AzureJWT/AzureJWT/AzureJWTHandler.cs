using AzureJWT.Constants;
using AzureJWT.Models;
using AzureJWT.Services;

namespace AzureJWT
{
    public class AzureJWTHandler
    {
        public async Task<string> GetJWTTokenAsync()
        {
            string token;
            using (var httpClient = new HttpClient(new HttpClientHandler() { UseProxy = false }))
            {
                token = await JWTService.GetJWTTokenAsync(httpClient);
            }
            return token;
        }

        public async Task<IEnumerable<string>> AuthenticateJWTAndGetRoles(string jwtTokenn)
        {
            var currentUser = OperationSystemService.GetCurrentUserName();

            if (string.IsNullOrEmpty(currentUser))
            {
                return null;
            }


            using (var httpClient = new HttpClient())
            {
                MicrosoftGraphService.AddBearTokenForRequest(httpClient, jwtTokenn);
                var listPrincipal = await MicrosoftGraphService.GetListUsersInApp(httpClient);
                var listAppRoles = await MicrosoftGraphService.GetListAppRolesInApp(httpClient);
                var listPrincipalContainCurrentUser = new List<PrincipalItem>();

                foreach (var principle in listPrincipal)
                {
                    principle.AppRoleName = listAppRoles.Where(a => a.Id == principle.AppRoleId).FirstOrDefault()?.DisplayName;
                    principle.AppRoleName = principle.AppRoleId == AppRoles.DefaultAccess ? nameof(AppRoles.DefaultAccess) : principle.AppRoleName;

                    if(principle.PrincipalType == PrincipalTypes.Group)
                    {
                        var listMember = await MicrosoftGraphService.GetListMemberInGroup(httpClient, principle.PrincipalId);
                        if(listMember?.Where(m => m.UserName == currentUser).Any() ?? false)
                        {
                            listPrincipalContainCurrentUser.Add(principle);
                        }
                    }
                }


                if (listPrincipalContainCurrentUser.Any())
                {
                    return listPrincipalContainCurrentUser.Select(u => u.AppRoleName).ToList();
                }
            }
            return null;
        }
    }
}
