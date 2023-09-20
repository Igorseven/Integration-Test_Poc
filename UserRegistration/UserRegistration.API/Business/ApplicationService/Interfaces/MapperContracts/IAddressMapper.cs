using UserRegistration.API.Business.ApplicationService.DataTransferObjects.Requests.AddressRequest;
using UserRegistration.API.Business.ApplicationService.DataTransferObjects.Responses.AddressResponse;
using UserRegistration.API.Business.Domain.Entities;

namespace UserRegistration.API.Business.ApplicationService.Interfaces.MapperContracts;
public interface IAddressMapper
{
    Address DtoRegisterToDomain(AddressClientRegisterRequest dtoAddress);
    List<Address> DtoRegisterToDomain(List<AddressClientRegisterRequest> dtoAddresses);
    AddressClientResponse DomainToCustomerDtoResponse(Address address);
    List<AddressClientResponse> DomainToCustomerDtoResponse(List<Address> addresses);
}
