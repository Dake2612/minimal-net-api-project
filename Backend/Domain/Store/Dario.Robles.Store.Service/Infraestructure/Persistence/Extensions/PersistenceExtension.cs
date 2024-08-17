using Dario.Robles.Store.Service.Domain.Orders.Interfaces;
using Dario.Robles.Store.Service.Infraestructure.Persistence.Contexts;
using Dario.Robles.Store.Service.Infraestructure.Persistence.Repository;
using Dario.Robles.Store.Service.Infraestructure.Persistence.UnitOfWork;
using Dario.Robles.Store.Service.Infrastructure.Persistence.Helpers.DataMapping.ModelMapping;
using Microsoft.EntityFrameworkCore;

namespace Dario.Robles.Store.Service.Infraestructure.Persistence.Extensions
{
    public class PersistenceOptions
    {
        public string ConnectionString { get; set; }
    }

    public static class PersistenceExtension
    {
        public static void UseSeedData(this IHost app)
        {
            var scopedFactory = app.Services.GetService<IServiceScopeFactory>();
            using (var scope = scopedFactory.CreateScope())
            {
                var context = scope.ServiceProvider.GetRequiredService<StoreContext>();
                context.EnsureSeedDataForContext();
            }
        }
        public static void AddPersistence(this IServiceCollection services, Action<PersistenceOptions> configure)
        {
            var options = new PersistenceOptions();
            configure(options);

            services.AddDbContext<StoreContext>(o => o.UseSqlServer(options.ConnectionString));
            services.AddScoped<IOrderRepository, OrderRepository>();
            services.AddScoped<IItemRepository, ItemRepository>();
            services.AddScoped<StoreUnitOfWork>();
            services.AddTransient<IOrderPropertyMappingService, OrderPropertyMappingService>();
        }
    }
}
