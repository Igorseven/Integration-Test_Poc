using UserRegistration.API.Business.ApplicationService.DataTransferObjects.Requests.EmailAddressRequest;
using UserRegistration.API.Business.ApplicationService.DataTransferObjects.Responses.EmailAddressResponse;
using UserRegistration.API.Business.ApplicationService.Interfaces.MapperContracts;
using UserRegistration.API.Business.Domain.Entities;

namespace UserRegistration.API.Business.ApplicationService.Mappers;
public sealed class EmailAddressMapper : IEmailAddressMapper
{
    public EmailAddress DtoRegisterToDomain(EmailAddressClientRegisterRequest dtoEmail) =>
        new()
        {
            EmailType = dtoEmail.EmailType,
            Email = dtoEmail.Email,
        };

    public List<EmailAddress> DtoRegisterToDomain(List<EmailAddressClientRegisterRequest> dtoEmails)
    {
        List<EmailAddress> emails = new();

        foreach (var dtoEmail in dtoEmails)
        {
            var email = DtoRegisterToDomain(dtoEmail);

            emails.Add(email);
        }

        return emails;
    }

    public EmailAddressClientResponse DomainToCustomerDtoResponse(EmailAddress email) =>
        new()
        {
            EmailAddressId = email.EmailAddressId,
            EmailType = email.EmailType,
            Email = email.Email
        };

    public List<EmailAddressClientResponse> DomainToCustomerDtoResponse(List<EmailAddress> emails)
    {
        List<EmailAddressClientResponse> dtoEmails = new();

        foreach (var email in emails)
        {
            var dtoEmail = DomainToCustomerDtoResponse(email);

            dtoEmails.Add(dtoEmail);
        }

        return dtoEmails;
    }
}
