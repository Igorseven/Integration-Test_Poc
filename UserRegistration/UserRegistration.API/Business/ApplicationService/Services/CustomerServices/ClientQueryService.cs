using UserRegistration.API.Business.ApplicationService.DataTransferObjects.Responses.ClientResponse;
using UserRegistration.API.Business.ApplicationService.Interfaces.MapperContracts;
using UserRegistration.API.Business.ApplicationService.Interfaces.ServiceContracts;
using UserRegistration.API.Business.Domain.Enums;
using UserRegistration.API.Business.Domain.Interfaces.RepositoryContracts;
using Microsoft.EntityFrameworkCore;

namespace UserRegistration.API.Business.ApplicationService.Services.ClientServices;
public sealed class ClientQueryService : IClientQueryService
{
    private readonly IClientRepository _clientRepository;
    private readonly IClientMapper _clientMapper;

    public ClientQueryService(IClientRepository clientRepository,
                              IClientMapper clientMapper)
    {
        _clientRepository = clientRepository;
        _clientMapper = clientMapper;
    }

    public async Task<IEnumerable<ClientDataResponse>> FindAllClientWithEmailAndMainTelephoneAsync()
    {
        var clients = await _clientRepository.FindAllAsync(c => c.Include(c => c.Emails.Where(e => e.EmailType == EEmailType.Main))
                                                                 .Include(c => c.Telephones));

        if (!clients.Any()) return Enumerable.Empty<ClientDataResponse>();

        return _clientMapper.DomainToDataDtoResponse(clients);
    }

    public async Task<ClientWithEmailAndMainAddressResponse?> FindByClientIdAsync(int clientId)
    {
        var client = await _clientRepository.FindByPredicateAsync(c => c.ClientId == clientId,
                                                                  c => c.Include(c => c.Emails.Where(e => e.EmailType == EEmailType.Main))
                                                                  .Include(c => c.Addresses.Where(a => a.AddressType == EAddressType.MainProperty)),
                                                                  true);

        if (client is null) return null;

        return _clientMapper.DomainToEmailAndMainAddressDtoResponse(client);
    }
}
