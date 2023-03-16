namespace AzureJWT.Models
{
    public class ADUser
    {
        public string GivenName { get; set; }
        public string Surname { get; set; }
        public string UserPrincipalName { get; set; }
        public bool Enabled { get; set; }
        public string SamAccountName { get; set; }
        public string DistinguishedName { get; set; }
        public string Name { get; set; }
        public string ObjectClass { get; set; }
        public string ObjectGuid { get; set; }
        public int PropertyCount { get; set; }
        public string ExternalDirectoryObjectId { get; set; }
    }
}
