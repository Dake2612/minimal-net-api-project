namespace Dario.Robles.Store.Service.Infraestructure.http.Extensions
{
    public static class CORSextensions
    {
        public static void AddAllowAllCORS(this IServiceCollection services) 
        {
            services.AddCors(options =>
            {
                options.AddPolicy("AllowAllCORS", builder =>
                {
                    builder
                    .AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader()
                    .WithExposedHeaders("X-Pagination");
                });
            });
        }
        public static void UseAllowAllCORS(this IApplicationBuilder app) 
        {
            app.UseCors("AllowAllCORS");
        }
    }
}
