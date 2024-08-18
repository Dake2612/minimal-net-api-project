using Dario.Robles.Store.Service.Infraestructure.http.Helpers.LinksBuilders;
using Dario.Robles.Store.Service.Infrastructure.Http.Extensions;
using Dario.Robles.Store.Service.Infrastructure.Http.Helpers.LinksBuilders;

namespace Dario.Robles.Store.Service.Infraestructure.http.Extensions
{
    public static class HttpExtensions
    {
        public static void AddHttp(this IServiceCollection services)
        {
            services.AddEndpointsApiExplorer();
            services.AddHttpContextAccessor();
            services.AddSwaggerDocumentation();
            services.AddScoped<IStoreLinksBuilder, StoreLinksBuilder>();
            services.AddScoped<IItemLinksBuilder, ItemLinksBuilder>();
        }
    }
}
