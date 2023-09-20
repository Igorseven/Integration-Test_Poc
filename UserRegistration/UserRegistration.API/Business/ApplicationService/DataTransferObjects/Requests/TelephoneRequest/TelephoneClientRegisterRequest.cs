using UserRegistration.API.Business.Domain.Enums;

namespace UserRegistration.API.Business.ApplicationService.DataTransferObjects.Requests.TelephoneRequest;
public sealed record TelephoneClientRegisterRequest
{
    public ETelephoneType TelephoneType { get; set; }
    public required string Ddi { get; set; }
    public string? Ddd { get; set; }
    public required string PhoneNumber { get; set; }
}
