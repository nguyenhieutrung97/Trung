// See https://aka.ms/new-console-template for more information
using AzureJWT;
using Newtonsoft.Json;
using System.DirectoryServices;
using System.DirectoryServices.AccountManagement;
using System.DirectoryServices.ActiveDirectory;
using System.Security.Principal;

var task = Task.Run(() => UserPrincipal.Current.EmailAddress);
if (task.Wait(TimeSpan.FromSeconds(1)))
{
    var x = task.Result;
}
var azureHandler = new AzureJWTHandler();
var token = await azureHandler.GetJWTTokenAsync();
Console.WriteLine(token);

var roles = await azureHandler.AuthenticateJWTAndGetRoles(token);

Console.WriteLine(JsonConvert.SerializeObject(roles, Formatting.Indented));


Console.ReadLine();
