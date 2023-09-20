using UserRegistration.API.Business.ApplicationService.DataTransferObjects.Responses.ClientResponse;

namespace UserRegistration.API.Business.ApplicationService.Interfaces.ServiceContracts;
public interface IClientQueryService
{
    Task<ClientWithEmailAndMainAddressResponse?> FindByClientIdAsync(int clientId);

    Task<IEnumerable<ClientDataResponse>> FindAllClientWithEmailAndMainTelephoneAsync();
}
