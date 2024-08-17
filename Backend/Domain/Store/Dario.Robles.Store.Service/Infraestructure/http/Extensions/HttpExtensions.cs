using Dario.Robles.Store.Service.Infrastructure.Http.Helpers.LinksBuilders;

namespace Dario.Robles.Store.Service.Infraestructure.http.Extensions
{
    public static class HttpExtensions
    {
        public static void AddHttp(this IServiceCollection services)
        {
            services.AddEndpointsApiExplorer();
            services.AddHttpContextAccessor();
            services.AddSwaggerGen();
            services.AddScoped<IStoreLinksBuilder, StoreLinksBuilder>();
        }
    }
}
