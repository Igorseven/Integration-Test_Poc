using UserRegistration.API.Business.ApplicationService.DataTransferObjects.Requests.ClientRequest;
using UserRegistration.API.Business.ApplicationService.Interfaces.MapperContracts;
using UserRegistration.API.Business.ApplicationService.Interfaces.ServiceContracts;
using UserRegistration.API.Business.Domain.Entities;
using UserRegistration.API.Business.Domain.Interfaces.OthersContracts;
using UserRegistration.API.Business.Domain.Interfaces.RepositoryContracts;

namespace UserRegistration.API.Business.ApplicationService.Services.ClientServices;
public sealed class ClientCommandService : BaseService<Client>, IClientCommandService
{
    private readonly IClientRepository _clientRepository;
    private readonly IClientMapper _clientMapper;

    public ClientCommandService(INotificationHandler notification,
                                  IValidate<Client> validate,
                                  IClientRepository clientRepository,
                                  IClientMapper clientMapper)
        : base(notification, validate)
    {
        _clientRepository = clientRepository;
        _clientMapper = clientMapper;
    }

    public void Dispose() => _clientRepository.Dispose();

    public async Task<bool> ClientRegisterAsync(ClientRegisterRequest dtoCustomer)
    {
        var customer = _clientMapper.DtoRegisterToDomain(dtoCustomer);

        if (!await EntityValidationAsync(customer)) return false;

        return await _clientRepository.SaveAsync(customer);
    }
}
