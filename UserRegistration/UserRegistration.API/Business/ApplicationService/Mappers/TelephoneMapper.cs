using UserRegistration.API.Business.ApplicationService.DataTransferObjects.Requests.TelephoneRequest;
using UserRegistration.API.Business.ApplicationService.DataTransferObjects.Responses.TelephoneResponse;
using UserRegistration.API.Business.ApplicationService.Interfaces.MapperContracts;
using UserRegistration.API.Business.Domain.Entities;
using UserRegistration.API.Business.Domain.Extensions;

namespace UserRegistration.API.Business.ApplicationService.Mappers;
public sealed class TelephoneMapper : ITelephoneMapper
{
    public Telephone DtoRegisterToDomain(TelephoneClientRegisterRequest dtoTelephone) =>
        new()
        {
            Ddi = dtoTelephone.Ddi.RemoveCaracters(),
            PhoneNumber = dtoTelephone.PhoneNumber.RemoveCaracters(),
            Ddd = dtoTelephone.Ddd?.RemoveCaracters(),
            TelephoneType = dtoTelephone.TelephoneType
        };

    public List<Telephone> DtoRegisterToDomain(List<TelephoneClientRegisterRequest> dtoTelephones)
    {
        List<Telephone> telephones = new();

        foreach (var dtoTelephone in dtoTelephones)
        {
            var telephone = DtoRegisterToDomain(dtoTelephone);

            telephones.Add(telephone);
        }

        return telephones;
    }

    public TelephoneClientResponse DomainToCustomerDtoResponse(Telephone telephone) =>
        new()
        {
            TelephoneId = telephone.TelephoneId,
            TelephoneType = telephone.TelephoneType,
            Ddi = telephone.Ddi,
            Ddd = telephone.Ddd,
            PhoneNumber = telephone.PhoneNumber
        };

    public List<TelephoneClientResponse> DomainToCustomerDtoResponse(List<Telephone> telephones)
    {
        List<TelephoneClientResponse> dtoPhones = new();

        foreach (var telephone in telephones)
        {
            var phone = DomainToCustomerDtoResponse(telephone);

            dtoPhones.Add(phone);
        }

        return dtoPhones;
    }
}
