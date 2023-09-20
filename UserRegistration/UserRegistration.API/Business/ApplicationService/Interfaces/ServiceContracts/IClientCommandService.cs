using UserRegistration.API.Business.ApplicationService.DataTransferObjects.Requests.ClientRequest;

namespace UserRegistration.API.Business.ApplicationService.Interfaces.ServiceContracts;
public interface IClientCommandService : IDisposable
{
    Task<bool> ClientRegisterAsync(ClientRegisterRequest dtoCustomer);
}
