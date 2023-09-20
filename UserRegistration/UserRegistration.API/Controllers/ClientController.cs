using UserRegistration.API.Business.ApplicationService.DataTransferObjects.Requests.ClientRequest;
using UserRegistration.API.Business.ApplicationService.DataTransferObjects.Responses.ClientResponse;
using UserRegistration.API.Business.ApplicationService.Interfaces.ServiceContracts;
using UserRegistration.API.Business.Domain.Handlers.NotificationHandler;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace UserRegistration.API.Controllers;

[Authorize]
[Route("api/[controller]")]
[ApiController]
public class ClientController : ControllerBase
{
    private readonly IClientCommandService _clientCommandService;
    private readonly IClientQueryService _clientQueryService;

    public ClientController(IClientCommandService clientCommandService,
                              IClientQueryService clientQueryService)
    {
        _clientCommandService = clientCommandService;
        _clientQueryService = clientQueryService;

    }

    [AllowAnonymous]
    [HttpPost("register_client")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(IEnumerable<DomainNotification>))]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<bool> ClientRegisterAsync([FromBody] ClientRegisterRequest dtoClientRegister) =>
        await _clientCommandService.ClientRegisterAsync(dtoClientRegister);

    [AllowAnonymous]
    [HttpGet("get_client_with_email_and_main_address")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ClientWithEmailAndMainAddressResponse?> GetClientWithEmailAndMainAddressAsync([FromQuery] int clientId) =>
        await _clientQueryService.FindByClientIdAsync(clientId);

    [AllowAnonymous]
    [HttpGet("get_all_clients")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IEnumerable<ClientDataResponse>> GetAllClientsAsync() =>
        await _clientQueryService.FindAllClientWithEmailAndMainTelephoneAsync();
}
