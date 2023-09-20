using UserRegistration.API.Business.Domain.Entities;
using UserRegistration.API.Business.Domain.EntitiesValidation;
using UserRegistration.API.Business.Domain.Interfaces.OthersContracts;

namespace UserRegistration.API.Settings.Configurations.DependencyInjectionSettings;

public static class ValidationDI
{
    public static IServiceCollection AddValidationDI(this IServiceCollection services) => 
        services.AddScoped<IValidate<Address>, AddressValidation>()
                .AddScoped<IValidate<EmailAddress>, EmailAddressValidation>()
                .AddScoped<IValidate<Telephone>, TelephoneValidation>()
                .AddScoped<IValidate<Client>, ClientValidation>();
}
