using UserRegistration.API.Business.ApplicationService.DataTransferObjects.Requests.TelephoneRequest;
using UserRegistration.API.Business.ApplicationService.DataTransferObjects.Responses.TelephoneResponse;
using UserRegistration.API.Business.Domain.Entities;

namespace UserRegistration.API.Business.ApplicationService.Interfaces.MapperContracts;
public interface ITelephoneMapper
{
    Telephone DtoRegisterToDomain(TelephoneClientRegisterRequest dtoTelephone);
    List<Telephone> DtoRegisterToDomain(List<TelephoneClientRegisterRequest> dtoTelephones);
    TelephoneClientResponse DomainToCustomerDtoResponse(Telephone telephone);
    List<TelephoneClientResponse> DomainToCustomerDtoResponse(List<Telephone> telephones);
}
