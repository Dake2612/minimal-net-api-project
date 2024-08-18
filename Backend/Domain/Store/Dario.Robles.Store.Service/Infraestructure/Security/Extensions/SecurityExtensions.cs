using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.IdentityModel.Tokens;

namespace Dario.Robles.Store.Service.Infrastructure.Security.Extensions
{
    public static class SecurityExtensions
    {
        public static void AddSecurity(this IServiceCollection services)
        {
            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(options =>
            {
                //options.Authority = "http://localhost:8081/realms/fullstack";
                options.Authority = "http://keycloak:8080/realms/fullstack";
                options.Audience = "store.service";
                options.RequireHttpsMetadata = false;
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidIssuer = "http://localhost:8081/realms/fullstack",
                    ValidateAudience = true,
                    ValidAudience = "store.service",
                    ValidateLifetime = true

                };
            });
            services.AddSingleton<IClaimsTransformation, RoleClaimsTransformer>();
            services.AddAuthorization();
        }
    }       
}
