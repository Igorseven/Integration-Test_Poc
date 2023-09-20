using UserRegistration.API.Business.ApplicationService.DataTransferObjects.Requests.AddressRequest;
using UserRegistration.API.Business.ApplicationService.DataTransferObjects.Requests.EmailAddressRequest;
using UserRegistration.API.Business.ApplicationService.DataTransferObjects.Requests.TelephoneRequest;

namespace UserRegistration.API.Business.ApplicationService.DataTransferObjects.Requests.ClientRequest;
public sealed record ClientRegisterRequest
{
    public required string FullName { get; set; }

    public required List<AddressClientRegisterRequest> Addresses { get; set; }
    public required List<EmailAddressClientRegisterRequest> Emails { get; set; }
    public required List<TelephoneClientRegisterRequest> Phones { get; set; }
}
