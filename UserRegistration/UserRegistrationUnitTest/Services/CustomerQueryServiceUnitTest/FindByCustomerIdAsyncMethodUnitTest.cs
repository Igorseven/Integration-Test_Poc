using Moq;
using UserRegistration.API.Business.ApplicationService.DataTransferObjects.Responses.AddressResponse;
using UserRegistration.API.Business.ApplicationService.DataTransferObjects.Responses.ClientResponse;
using UserRegistration.API.Business.Domain.Entities;
using UserRegistration.API.Business.Domain.Enums;
using UserRegistration.UserRegistrationUnitTest.Builders;
using UserRegistration.UserRegistrationUnitTest.Services.ClientQueryServiceUnitTest.Base;

namespace UserRegistration.UserRegistrationUnitTest.Services.ClientQueryServiceUnitTest;
public sealed class FindByCustomerIdAsyncMethodUnitTest : ClientQueryServiceSetup
{
    [Fact]
    [Trait("Query", "Return dto ClientWithEmailAndMainAddressResponse")]
    public async Task FindByClientIdAsync_ResponseClientWithEmailAndMainAddressResponse()
    {
        var clientId = 1;
        var client = ClientBuilderTest.NewObject().DomainObject();
        var dtoClient = new ClientWithEmailAndMainAddressResponse
        {
            ClientId = 1,
            FullName = "Customer full name",
            Email = "email@test.com",
            Address = new AddressClientResponse
            {
                AddressId = 1,
                AddressType = EAddressType.MainProperty,
                Localization = "Localization",
                District = "District",
                City = "City",
                Country = "Country",
                Number = "15A",
                State = "state",
                ZipCode = "80009000",
                Complement = null
            }
        };

        _clientRepository.Setup(r => r.FindByPredicateAsync(UtilTools.BuildPredicateFunc<Client>(),
                                                              UtilTools.BuildQueryableIncludeFunc<Client>(),
                                                              true)).ReturnsAsync(client);
        _clientMapper.Setup(m => m.DomainToEmailAndMainAddressDtoResponse(It.IsAny<Client>())).Returns(dtoClient);

        var serviceResult = await _clientQueryService.FindByClientIdAsync(clientId);

        Assert.NotNull(serviceResult);
        _clientRepository.Verify(r => r.FindByPredicateAsync(UtilTools.BuildPredicateFunc<Client>(),
                                                               UtilTools.BuildQueryableIncludeFunc<Client>(),
                                                               true), Times.Once());
        _clientMapper.Verify(m => m.DomainToEmailAndMainAddressDtoResponse(It.IsAny<Client>()), Times.Once());
    }


    [Fact]
    [Trait("Query", "Return null")]
    public async Task FindByClientIdAsync_ResponseNull()
    {
        var clientId = 1;

        _clientRepository.Setup(r => r.FindByPredicateAsync(UtilTools.BuildPredicateFunc<Client>(),
                                                            UtilTools.BuildQueryableIncludeFunc<Client>(),
                                                            true));

        var serviceResult = await _clientQueryService.FindByClientIdAsync(clientId);

        Assert.Null(serviceResult);
        _clientRepository.Verify(r => r.FindByPredicateAsync(UtilTools.BuildPredicateFunc<Client>(),
                                                             UtilTools.BuildQueryableIncludeFunc<Client>(),
                                                             true), Times.Once());
        _clientMapper.Verify(m => m.DomainToEmailAndMainAddressDtoResponse(It.IsAny<Client>()), Times.Never());
    }
}
