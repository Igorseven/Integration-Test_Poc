using UserRegistration.API.Business.ApplicationService.Interfaces.MapperContracts;
using UserRegistration.API.Business.ApplicationService.Services.ClientServices;
using UserRegistration.API.Business.Domain.Interfaces.RepositoryContracts;
using Moq;

namespace UserRegistration.UserRegistrationUnitTest.Services.ClientQueryServiceUnitTest.Base;
public abstract class ClientQueryServiceSetup
{
    protected readonly Mock<IClientRepository> _clientRepository;
    protected readonly Mock<IClientMapper> _clientMapper;
    protected readonly ClientQueryService _clientQueryService;

    public ClientQueryServiceSetup()
    {
        _clientRepository = new();
        _clientMapper = new();
        _clientQueryService = new(_clientRepository.Object,
                                    _clientMapper.Object);
    }
}
