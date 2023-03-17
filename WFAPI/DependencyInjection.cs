using System.Data.Entity;
using Worflow.Dados.EFCore;
using Worflow.Dados.Interfaces;
using Worflow.Repository;
using Worflow.Services;

namespace WFAPI;

public static class DependencyInjection
{
    public static IServiceCollection AddInterfaces(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<AppDbContext>();

        services.AddTransient<IPerfilRepository, PerfilEF>();
        services.AddTransient<IPerfilService, PerfilService>();

        return services;
    }
}
