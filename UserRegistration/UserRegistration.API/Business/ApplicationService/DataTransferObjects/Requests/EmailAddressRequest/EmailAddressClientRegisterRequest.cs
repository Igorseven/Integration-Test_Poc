using UserRegistration.API.Business.Domain.Enums;

namespace UserRegistration.API.Business.ApplicationService.DataTransferObjects.Requests.EmailAddressRequest;
public sealed record EmailAddressClientRegisterRequest
{
    public EEmailType EmailType { get; set; }
    public required string Email { get; set; }
}
