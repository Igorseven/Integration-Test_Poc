using UserRegistration.API.Business.Domain.Enums;

namespace UserRegistration.API.Business.ApplicationService.DataTransferObjects.Responses.EmailAddressResponse;
public sealed record EmailAddressClientResponse
{
    public int EmailAddressId { get; set; }
    public EEmailType EmailType { get; set; }
    public required string Email { get; set; }
}
