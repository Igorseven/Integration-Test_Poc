using UserRegistration.API.Business.Domain.Interfaces.RepositoryContracts;
using UserRegistration.API.Business.Insfrastructure.Repository;

namespace UserRegistration.API.Settings.Configurations.DependencyInjectionSettings;

public static class RepositoryDI
{
    public static IServiceCollection AddRepositoryDI(this IServiceCollection services) =>
        services.AddScoped<IClientRepository, ClientRepository>();
}
