using UserRegistration.API.Business.ApplicationService.Interfaces.ServiceContracts;
using UserRegistration.API.Business.ApplicationService.Services.ClientServices;

namespace UserRegistration.API.Settings.Configurations.DependencyInjectionSettings;

public static class ServiceDI
{
    public static IServiceCollection AddServiceDI(this IServiceCollection services) =>
        services.AddScoped<IClientQueryService, ClientQueryService>()
                .AddScoped<IClientCommandService, ClientCommandService>();
}
