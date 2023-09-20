using UserRegistration.API.Business.Domain.Enums;

namespace UserRegistration.API.Business.Domain.Entities;
public sealed class EmailAddress
{
    public int EmailAddressId { get; set; }
    public EEmailType EmailType { get; set; }
    public required string Email { get; set; }

    public int ClientId { get; set; }
}
