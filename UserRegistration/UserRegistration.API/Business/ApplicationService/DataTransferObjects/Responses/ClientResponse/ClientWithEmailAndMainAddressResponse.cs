using UserRegistration.API.Business.ApplicationService.DataTransferObjects.Responses.AddressResponse;

namespace UserRegistration.API.Business.ApplicationService.DataTransferObjects.Responses.ClientResponse;
public sealed record ClientWithEmailAndMainAddressResponse
{
    public int ClientId { get; set; }
    public required string FullName { get; set; }
    public required string Email { get; set; }
    public required AddressClientResponse Address { get; set; }
}
