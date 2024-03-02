using Limakaz.Database;
using Limakaz.Services.Abstract;
using Limakaz.Services.Concretes;
using Microsoft.EntityFrameworkCore;

namespace Limakaz.Extensions;


public static class IServiceCollectionExtensions
{
    public static void AddConrollers(this IServiceCollection services)
    {
        services
            .AddControllersWithViews()
            .AddRazorRuntimeCompilation();

    }

    public static void AddCustomService(this IServiceCollection services, IConfiguration configuration)
    {
        services.
             AddHttpContextAccessor()
            .AddScoped<IRegisterService, RegisterService>()
            .AddDbContext<LimakDbContext>(o =>
        {
            var connectionString = configuration.GetConnectionString("LimakKargo");
            o.UseNpgsql(connectionString);
        });
    }
}
    