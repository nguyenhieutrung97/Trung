namespace AzureJWT.Constants
{
    internal static class ExecutionCommand
    {
        internal static string GetCurrentADUser =
            @"
                $curUser = Get-ADUser ($env:UserName) -Server ($env:USERDNSDOMAIN) -Properties msDS-ExternalDirectoryObjectId
                 ConvertTo-Json -InputObject $curUser
            ";

    }
}
