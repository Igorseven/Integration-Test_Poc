using UserRegistration.API.Business.ApplicationService.DataTransferObjects.Requests.AddressRequest;
using UserRegistration.API.Business.ApplicationService.DataTransferObjects.Requests.ClientRequest;
using UserRegistration.API.Business.ApplicationService.DataTransferObjects.Requests.EmailAddressRequest;
using UserRegistration.API.Business.ApplicationService.DataTransferObjects.Requests.TelephoneRequest;
using UserRegistration.API.Business.Domain.Enums;
using UserRegistration.API.Business.Domain.Entities;
using UserRegistration.UserRegistrationUnitTest.Services.ClientCommandServiceUnitTest.Base;
using Moq;

namespace UserRegistration.UserRegistrationUnitTest.Services.ClientCommandServiceUnitTest;
public sealed class ClientRegisterAsyncMethodUnitTest : ClientCommandServiceSetup
{

    public static IEnumerable<object[]> CustomerRegisterRequestPerfectSetting()
    {
        yield return new object[]
        {
            new ClientRegisterRequest
            {
                FullName = "User full name",
                Emails = new List<EmailAddressClientRegisterRequest>()
                {
                    new()
                    {
                        EmailType = EEmailType.Main,
                        Email = "email@test.com"
                    }
                },
                Phones = new List<TelephoneClientRegisterRequest>()
                {
                    new()
                    {
                        Ddi = "+55",
                        Ddd = "(18)",
                        PhoneNumber = "91172-4588",
                        TelephoneType = ETelephoneType.CellPhone
                    },
                    new()
                    {
                        Ddi = "+55",
                        Ddd = "(18)",
                        PhoneNumber = "3371-1566",
                        TelephoneType = ETelephoneType.Landline
                    }
                },
                Addresses = new List<AddressClientRegisterRequest>()
                {
                    new()
                    {
                        AddressType = EAddressType.MainProperty,
                        Localization = "Localization",
                        District = "District",
                        City = "City",
                        Number = "12B",
                        State = "SP",
                        Country = "Country",
                        ZipCode = "80009000",
                        Complement = null
                    }
                }
            }
        };
    }

    [Theory]
    [Trait("Success", "Perfect setting")]
    [MemberData(nameof(CustomerRegisterRequestPerfectSetting))]
    public async Task CustomerRegisterAsync_PerfectSetting_ReturnTrue(ClientRegisterRequest customerRegisterRequest)
    {
        _clientMapper.Setup(m => m.DtoRegisterToDomain(It.IsAny<ClientRegisterRequest>())).Returns(It.IsAny<Client>());
        _validate.Setup(v => v.ValidationAsync(It.IsAny<Client>())).ReturnsAsync(_validationResponse);
        _clientRepository.Setup(r => r.SaveAsync(It.IsAny<Client>())).ReturnsAsync(true);

        var serviceResult = await _clientCommandService.ClientRegisterAsync(customerRegisterRequest);

        Assert.True(serviceResult);
        _clientMapper.Verify(m => m.DtoRegisterToDomain(It.IsAny<ClientRegisterRequest>()), Times.Once());
        _validate.Verify(v => v.ValidationAsync(It.IsAny<Client>()), Times.Once());
        _clientRepository.Verify(r => r.SaveAsync(It.IsAny<Client>()), Times.Once());
    }


    [Fact]
    [Trait("Failed", "Invalid data")]
    public async Task CustomerRegisterAsync_InvalidData_ReturnFalse()
    {
        CreateInvalidDataNotification();
        _clientMapper.Setup(m => m.DtoRegisterToDomain(It.IsAny<ClientRegisterRequest>())).Returns(It.IsAny<Client>());
        _validate.Setup(v => v.ValidationAsync(It.IsAny<Client>())).ReturnsAsync(_validationResponse);

        var serviceResult = await _clientCommandService.ClientRegisterAsync(It.IsAny<ClientRegisterRequest>());

        Assert.False(serviceResult);
        _clientMapper.Verify(m => m.DtoRegisterToDomain(It.IsAny<ClientRegisterRequest>()), Times.Once());
        _validate.Verify(v => v.ValidationAsync(It.IsAny<Client>()), Times.Once());
        _clientRepository.Verify(r => r.SaveAsync(It.IsAny<Client>()), Times.Never());
    }
}
