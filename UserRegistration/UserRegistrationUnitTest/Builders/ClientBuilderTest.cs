
using UserRegistration.API.Business.Domain.Entities;

namespace UserRegistration.UserRegistrationUnitTest.Builders;
public sealed class ClientBuilderTest
{
    private int _clientId = 1;
    private string _fullName = "Customer full name";
    private List<Address> _addresses = new();
    private List<Telephone> _telephones = new();
    private List<EmailAddress> _emails = new();

    public static ClientBuilderTest NewObject() => new();

    public Client DomainObject() =>
        new()
        {
            ClientId = _clientId,
            FullName = _fullName,
            Addresses = _addresses,
            Telephones = _telephones,
            Emails = _emails
        };

    public ClientBuilderTest WithId(int customerId)
    {
        _clientId = customerId;
        return this;
    }

    public ClientBuilderTest WithFullName(string fullName)
    {
        _fullName = fullName;
        return this;
    }

    public ClientBuilderTest WithAddresses(Address address)
    {
        _addresses.Add(address);
        return this;
    }

    public ClientBuilderTest WithTelephones(Telephone telephone)
    {
        _telephones.Add(telephone);
        return this;
    }

    public ClientBuilderTest WithEmails(EmailAddress emailAddress)
    {
        _emails.Add(emailAddress);
        return this;
    }

    public ClientBuilderTest WithAllRelationships()
    {
        var email = EmailAddressBuilderTest.NewObject().DomainObject();
        var telphone = TelephoneBuilderTest.NewObject().DomainObject();
        var address = AddressBuilderTest.NewObject().DomainObject();

        _emails.Add(email);
        _telephones.Add(telphone);
        _addresses.Add(address);

        return this;
    }
}
