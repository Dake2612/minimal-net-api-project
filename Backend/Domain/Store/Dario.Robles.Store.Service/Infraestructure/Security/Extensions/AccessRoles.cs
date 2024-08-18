using System.Text.Json.Serialization;

namespace Dario.Robles.Store.Service.Infrastructure.Security.Extensions
{
    public class AccessRoles
    {
        [JsonPropertyName("roles")]
        public List<string> Roles { get; set; }
    }
}
