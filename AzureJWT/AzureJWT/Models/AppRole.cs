namespace AzureJWT.Models
{
    public class AppRole
    {
        public string[] AllowedMemberTypes { get; set; }
        public string Description { get; set; }
        public string DisplayName { get; set; }
        public string Id { get; set; }
        public bool IsEnabled { get; set; }
        public string Origin { get; set; }
        public string Value { get; set; }

    }
}
