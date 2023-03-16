using System.Collections.Generic;

namespace AzureJWT.Models
{
    public class ServicePrincipalResponse<T>
    {
        public IEnumerable<T> Value { get; set; }
    }
}
