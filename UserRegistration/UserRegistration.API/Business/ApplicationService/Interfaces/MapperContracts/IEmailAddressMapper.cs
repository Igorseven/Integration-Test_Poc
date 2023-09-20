using UserRegistration.API.Business.ApplicationService.DataTransferObjects.Requests.EmailAddressRequest;
using UserRegistration.API.Business.ApplicationService.DataTransferObjects.Responses.EmailAddressResponse;
using UserRegistration.API.Business.Domain.Entities;

namespace UserRegistration.API.Business.ApplicationService.Interfaces.MapperContracts;
public interface IEmailAddressMapper
{
    EmailAddress DtoRegisterToDomain(EmailAddressClientRegisterRequest dtoEmail);
    List<EmailAddress> DtoRegisterToDomain(List<EmailAddressClientRegisterRequest> dtoEmails);
    EmailAddressClientResponse DomainToCustomerDtoResponse(EmailAddress email);
    List<EmailAddressClientResponse> DomainToCustomerDtoResponse(List<EmailAddress> emails);
}
