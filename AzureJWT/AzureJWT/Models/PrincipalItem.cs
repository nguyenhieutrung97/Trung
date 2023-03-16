using AzureJWT.Constants;
using System;

namespace AzureJWT.Models
{
    public class PrincipalItem
    {
        public string Id { get; set; }
        public object DeletedDateTime { get; set; }
        public string AppRoleId { get; set; }
        public string AppRoleName { get; set; }
        public DateTime CreatedDateTime { get; set; }
        public string PrincipalDisplayName { get; set; }
        public string PrincipalId { get; set; }
        public string PrincipalType { get; set; }
        public string ResourceDisplayName { get; set; }
        public string ResourceId { get; set; }
    }
}
