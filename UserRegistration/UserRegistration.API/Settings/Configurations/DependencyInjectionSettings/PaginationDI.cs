using UserRegistration.API.Business.Domain.Entities;
using UserRegistration.API.Business.Domain.Interfaces.OthersContracts;
using UserRegistration.API.Business.Insfrastructure.Services;

namespace UserRegistration.API.Settings.Configurations.DependencyInjectionSettings;

public static class PaginationDI
{
    public static IServiceCollection AddPaginationDI(this IServiceCollection services) =>
        services.AddScoped<IPaginationQueryService<Client>, PaginationQueryService<Client>>();
}
