using UserRegistration.API.Business.Domain.Enums;

namespace UserRegistration.API.Business.Domain.Entities;
public sealed class Telephone
{
    public int TelephoneId { get; set; }
    public ETelephoneType TelephoneType { get; set; }
    public required string Ddi { get; set; }
    public string? Ddd { get; set; }
    public required string PhoneNumber { get; set; }

    public int ClientId { get; set; }
}
