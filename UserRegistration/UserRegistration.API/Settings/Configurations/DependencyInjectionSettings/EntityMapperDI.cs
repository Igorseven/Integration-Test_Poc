using UserRegistration.API.Business.ApplicationService.Interfaces.MapperContracts;
using UserRegistration.API.Business.ApplicationService.Mappers;

namespace UserRegistration.API.Settings.Configurations.DependencyInjectionSettings;

public static class EntityMapperDI
{
    public static IServiceCollection AddEntityMapperDI(this IServiceCollection services) =>
        services.AddScoped<IClientMapper, ClientMapper>()
                .AddScoped<IEmailAddressMapper, EmailAddressMapper>()
                .AddScoped<ITelephoneMapper, TelephoneMapper>()
                .AddScoped<IAddressMapper, AddressMapper>();
        
}
