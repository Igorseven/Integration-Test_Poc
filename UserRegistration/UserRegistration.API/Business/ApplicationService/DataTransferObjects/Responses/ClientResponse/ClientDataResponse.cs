namespace UserRegistration.API.Business.ApplicationService.DataTransferObjects.Responses.ClientResponse;
public sealed record ClientDataResponse
{
    public int ClientId { get; set; }
    public required string FullName { get; set; }
    public required string PhoneNumber { get; set; }
    public required string Email { get; set; }

}
