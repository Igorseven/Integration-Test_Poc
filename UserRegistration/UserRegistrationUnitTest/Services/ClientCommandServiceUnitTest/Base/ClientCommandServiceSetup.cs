using UserRegistration.API.Business.ApplicationService.Interfaces.MapperContracts;
using UserRegistration.API.Business.ApplicationService.Services.ClientServices;
using UserRegistration.API.Business.Domain.Handlers.ValidationHandler;
using UserRegistration.API.Business.Domain.Interfaces.OthersContracts;
using UserRegistration.API.Business.Domain.Interfaces.RepositoryContracts;
using UserRegistration.API.Business.Domain.Entities;
using Moq;

namespace UserRegistration.UserRegistrationUnitTest.Services.ClientCommandServiceUnitTest.Base;
public abstract class ClientCommandServiceSetup
{
    protected readonly Mock<INotificationHandler> _notification;
    protected readonly Mock<IValidate<Client>> _validate;
    protected readonly Mock<IClientRepository> _clientRepository;
    protected readonly Mock<IClientMapper> _clientMapper;
    protected readonly ValidationResponse _validationResponse;
    protected readonly ClientCommandService _clientCommandService;
    private readonly Dictionary<string, string> _errors;

    public ClientCommandServiceSetup()
    {
        _notification = new();
        _validate = new();
        _clientRepository = new();
        _clientMapper = new();
        _errors = new();
        _validationResponse = ValidationResponse.CreateResponse(_errors);
        _clientCommandService = new(_notification.Object,
                                      _validate.Object,
                                      _clientRepository.Object,
                                      _clientMapper.Object);
    }

    protected void CreateInvalidDataNotification() =>
        _errors.Add("Error", "Error"); 
}
