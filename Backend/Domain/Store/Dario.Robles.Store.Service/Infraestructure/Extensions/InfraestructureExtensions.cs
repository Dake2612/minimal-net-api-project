using Dario.Robles.Store.Service.Infraestructure.http.Extensions;
using Dario.Robles.Store.Service.Infraestructure.Persistence.Extensions;
using Microsoft.AspNetCore.Builder;

namespace Dario.Robles.Store.Service.Infraestructure.Extensions
{
    public class InfrastructureOptions
    {
        public string ConnectionString { get; set; }
    }
    public static class InfrastructureExtensions
    {
        public static void AddInfrastructure(this IServiceCollection services, Action<InfrastructureOptions> configure)
        {
            var options = new InfrastructureOptions();
            configure(options);

            services.AddHttp();
            services.AddPersistence(opt => opt.ConnectionString = options.ConnectionString);
        }
    }
}
