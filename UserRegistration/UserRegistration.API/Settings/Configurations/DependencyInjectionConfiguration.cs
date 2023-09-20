using UserRegistration.API.Business.Domain.Handlers.NotificationHandler;
using UserRegistration.API.Business.Domain.Interfaces.OthersContracts;
using UserRegistration.API.Business.Domain.Providers;
using UserRegistration.API.Business.Insfrastructure.ORM.Context;
using UserRegistration.API.Business.Insfrastructure.ORM.UoW;
using UserRegistration.API.Settings.Configurations.DependencyInjectionSettings;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace UserRegistration.API.Settings.Configurations;

public static class DependencyInjectionConfiguration
{
    public static IServiceCollection AddDependencyInjectionConfiguration(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped<ApplicationContext>()
                .AddScoped<INotificationHandler, NotificationHandler>()
                .AddScoped<IUnitOfWork, UnitOfWork>();

        services.AddTransient(sp => sp.GetService<IOptionsMonitor<ConnectionStringOptions>>()!.CurrentValue);
        services.Configure<ConnectionStringOptions>(configuration.GetSection(ConnectionStringOptions.SectionName));

        services.AddDbContext<ApplicationContext>((serviceProv, options) =>
           options.UseSqlServer(serviceProv.GetRequiredService<ConnectionStringOptions>().DefaultConnection, sql => sql.CommandTimeout(180)));


        services.AddValidationDI()
                .AddRepositoryDI()
                .AddPaginationDI()
                .AddServiceDI()
                .AddEntityMapperDI();

        return services;
    }
}
