namespace UserRegistration.API.Business.Domain.Entities;
public sealed class Client
{
    public int ClientId { get; set; }
    public required string FullName { get; set; }

    public required List<Address> Addresses { get; set; }
    public required List<Telephone> Telephones { get; set; }
    public required List<EmailAddress> Emails { get; set; }
}
