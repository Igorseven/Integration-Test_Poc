using UserRegistration.API.Business.ApplicationService.DataTransferObjects.Requests.ClientRequest;
using UserRegistration.API.Business.ApplicationService.DataTransferObjects.Responses.ClientResponse;
using UserRegistration.API.Business.Domain.Entities;

namespace UserRegistration.API.Business.ApplicationService.Interfaces.MapperContracts;
public interface IClientMapper
{
    Client DtoRegisterToDomain(ClientRegisterRequest dtoCustomer);

    ClientDataResponse DomainToDataDtoResponse(Client customer);

    List<ClientDataResponse> DomainToDataDtoResponse(List<Client> customers);

    ClientWithEmailAndMainAddressResponse DomainToEmailAndMainAddressDtoResponse(Client customer);

}
