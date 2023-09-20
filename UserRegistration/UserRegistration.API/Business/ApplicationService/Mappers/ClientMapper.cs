using UserRegistration.API.Business.ApplicationService.DataTransferObjects.Requests.ClientRequest;
using UserRegistration.API.Business.ApplicationService.DataTransferObjects.Responses.ClientResponse;
using UserRegistration.API.Business.ApplicationService.Interfaces.MapperContracts;
using UserRegistration.API.Business.Domain.Entities;
using UserRegistration.API.Business.Domain.Enums;
using UserRegistration.API.Business.Domain.Extensions;

namespace UserRegistration.API.Business.ApplicationService.Mappers;
public sealed class ClientMapper : IClientMapper
{
    private readonly IAddressMapper _addressMapper;
    private readonly IEmailAddressMapper _emailAddressMapper;
    private readonly ITelephoneMapper _telephoneMapper;

    public ClientMapper(IAddressMapper addressMapper,
                        IEmailAddressMapper emailAddressMapper,
                        ITelephoneMapper telephoneMapper)
    {
        _addressMapper = addressMapper;
        _emailAddressMapper = emailAddressMapper;
        _telephoneMapper = telephoneMapper;
    }

    public Client DtoRegisterToDomain(ClientRegisterRequest dtoCustomer) =>
        new()
        {
            FullName = dtoCustomer.FullName,
            Addresses = _addressMapper.DtoRegisterToDomain(dtoCustomer.Addresses),
            Emails = _emailAddressMapper.DtoRegisterToDomain(dtoCustomer.Emails),
            Telephones = _telephoneMapper.DtoRegisterToDomain(dtoCustomer.Phones)
        };


    public ClientDataResponse DomainToDataDtoResponse(Client customer)
    {
        var phone = customer.Telephones.FirstOrDefault();
        var emailAddress = customer.Emails.FirstOrDefault();

        return new()
        {
            ClientId = customer.ClientId,
            FullName = customer.FullName,
            Email = emailAddress!.Email,
            PhoneNumber = phone!.PhoneNumberMask()
        };
    }

    public List<ClientDataResponse> DomainToDataDtoResponse(List<Client> customers)
    {
        List<ClientDataResponse> dtoCustomers = new();

        foreach (var customer in customers)
        {
            var dtoCustomer = DomainToDataDtoResponse(customer); 
            
            dtoCustomers.Add(dtoCustomer);
        }

        return dtoCustomers;
    }



    public ClientWithEmailAndMainAddressResponse DomainToEmailAndMainAddressDtoResponse(Client customer)
    {
        var mainAddress = customer.Addresses.FirstOrDefault(a => a.AddressType == EAddressType.MainProperty);
        var mainEmail = customer.Emails.FirstOrDefault(e => e.EmailType == EEmailType.Main);

        return new()
        {
            ClientId = customer.ClientId,
            FullName = customer.FullName,
            Email = mainEmail!.Email,
            Address = _addressMapper.DomainToCustomerDtoResponse(mainAddress!)
        };
    }
}
