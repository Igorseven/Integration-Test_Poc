using Moq;
using UserRegistration.API.Business.ApplicationService.DataTransferObjects.Responses.ClientResponse;
using UserRegistration.API.Business.Domain.Entities;
using UserRegistration.UserRegistrationUnitTest.Builders;
using UserRegistration.UserRegistrationUnitTest.Services.ClientQueryServiceUnitTest.Base;

namespace UserRegistration.UserRegistrationUnitTest.Services.ClientQueryServiceUnitTest;
public sealed class FindAllCustomerWithEmailAndMainTelephoneAsyncMethodUnitTest : ClientQueryServiceSetup
{

    public static IEnumerable<object[]> CustomerDataResponseList()
    {
        yield return new object[]
        {
            new List<ClientDataResponse>
            {
                new()
                {
                    ClientId = 1,
                    FullName = "David Test",
                    Email = "email@test.com",
                    PhoneNumber = "+55 (18) 91172-4685"
                }, 
                new()
                {
                    ClientId = 2,
                    FullName = "Louis Test",
                    Email = "loiusemail@test.com",
                    PhoneNumber = "+55 (18) 91172-5022"
                }, 
                new()
                {
                    ClientId = 3,
                    FullName = "Bruna Test",
                    Email = "brunaemail@test.com",
                    PhoneNumber = "+55 (18) 91172-3326"
                },
            },

            new List<Client>()
            {
                { ClientBuilderTest.NewObject().WithId(1).DomainObject() },
                { ClientBuilderTest.NewObject().WithId(2).DomainObject() },
                { ClientBuilderTest.NewObject().WithId(3).DomainObject() }
            }
        };
    }


    [Theory]
    [Trait("Query", "Return dto ClientDataResponse list")]
    [MemberData(nameof(CustomerDataResponseList))]
    public async Task FindAllClientWithEmailAndMainTelephoneAsync_ReturnClientDataResponseList(List<ClientDataResponse> dtoClients,
                                                                                                 List<Client> clients)
    {
        _clientRepository.Setup(r => r.FindAllAsync(UtilTools.BuildQueryableIncludeFunc<Client>())).ReturnsAsync(clients);
        _clientMapper.Setup(m => m.DomainToDataDtoResponse(It.IsAny<List<Client>>())).Returns(dtoClients);

        var serviceResult = await _clientQueryService.FindAllClientWithEmailAndMainTelephoneAsync();

        Assert.NotEmpty(serviceResult);
        _clientRepository.Verify(r => r.FindAllAsync(UtilTools.BuildQueryableIncludeFunc<Client>()), Times.Once());
        _clientMapper.Verify(m => m.DomainToDataDtoResponse(It.IsAny<List<Client>>()), Times.Once());

    }

    [Fact]
    [Trait("Query", "return empty list")]
    public async Task FindAllClientWithEmailAndMainTelephoneAsync_ReturnEmptyList()
    {
        var clients = new List<Client>() { };

        _clientRepository.Setup(r => r.FindAllAsync(UtilTools.BuildQueryableIncludeFunc<Client>())).ReturnsAsync(clients);

        var serviceResult = await _clientQueryService.FindAllClientWithEmailAndMainTelephoneAsync();

        Assert.Empty(serviceResult);
        _clientRepository.Verify(r => r.FindAllAsync(UtilTools.BuildQueryableIncludeFunc<Client>()), Times.Once());
        _clientMapper.Verify(m => m.DomainToDataDtoResponse(It.IsAny<List<Client>>()), Times.Never());

    }
}
