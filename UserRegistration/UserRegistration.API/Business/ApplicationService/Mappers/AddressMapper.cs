using UserRegistration.API.Business.ApplicationService.DataTransferObjects.Requests.AddressRequest;
using UserRegistration.API.Business.ApplicationService.DataTransferObjects.Responses.AddressResponse;
using UserRegistration.API.Business.ApplicationService.Interfaces.MapperContracts;
using UserRegistration.API.Business.Domain.Entities;
using UserRegistration.API.Business.Domain.Extensions;

namespace UserRegistration.API.Business.ApplicationService.Mappers;
public sealed class AddressMapper : IAddressMapper
{

    public Address DtoRegisterToDomain(AddressClientRegisterRequest dtoAddress) =>
        new()
        {
            AddressType = dtoAddress.AddressType,
            Localization = dtoAddress.Localization,
            District = dtoAddress.District,
            Number = dtoAddress.Number,
            City = dtoAddress.City,
            State = dtoAddress.State,
            Country = dtoAddress.Country,
            ZipCode = dtoAddress.ZipCode.RemoveCaracters(),
            Complement = dtoAddress.Complement
        };

    public List<Address> DtoRegisterToDomain(List<AddressClientRegisterRequest> dtoAddresses)
    {
        List<Address> adresses = new();

        foreach (var dtoAddress in dtoAddresses)
        {
            var address = DtoRegisterToDomain(dtoAddress);

            adresses.Add(address);
        }

        return adresses;
    }

    public AddressClientResponse DomainToCustomerDtoResponse(Address address) =>
        new()
        {
            AddressId = address.AddressId,
            AddressType = address.AddressType,
            Localization = address.Localization,
            District = address.District,
            Number = address.Number,
            City = address.City,
            State = address.State,
            Country = address.Country,
            ZipCode = address.ZipCode,
            Complement = address.Complement
        };

    public List<AddressClientResponse> DomainToCustomerDtoResponse(List<Address> addresses)
    {
        List<AddressClientResponse> dtoAdresses = new();

        foreach (var address in addresses)
        {
            var dtoAddress = DomainToCustomerDtoResponse(address);

            dtoAdresses.Add(dtoAddress);
        }

        return dtoAdresses;
    }
}
