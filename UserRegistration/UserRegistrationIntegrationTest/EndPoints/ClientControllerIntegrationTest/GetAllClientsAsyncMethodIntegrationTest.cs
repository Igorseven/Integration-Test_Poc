using Newtonsoft.Json;
using System.Net;
using System.Net.Http.Json;
using UserRegistration.API.Business.ApplicationService.DataTransferObjects.Requests.ClientRequest;
using UserRegistration.API.Business.ApplicationService.DataTransferObjects.Responses.ClientResponse;
using UserRegistration.API.Business.Domain.Enums;
using UserRegistrationIntegrationTest.EndPoints.Settings;

namespace UserRegistrationIntegrationTest.EndPoints.ClientControllerIntegrationTest;
public sealed class GetAllClientsAsyncMethodIntegrationTest : BaseIntegrationTest
{

    private const string _endPointGetUrl = "api/Client/get_all_clients";
    private const string _endPointPostUrl = "api/Client/register_client";

    public GetAllClientsAsyncMethodIntegrationTest(IntegrationTestWebAppFactory factory) 
        : base(factory)
    {
    }

    [Fact]
    [Trait("OK", "Return dto data response list")]
    public async Task GetAllClientsAsync_ReturnClientDataResponseList()
    {
        var dtoRegisterOne = new ClientRegisterRequest
        {
            FullName = "Tester test",
            Addresses = new()
            {
                new()
                {
                    Country = "Country",
                    State = "SP",
                    City = "City",
                    Localization = "Localization",
                    District = "District",
                    Complement = "Complement",
                    Number = "185A",
                    ZipCode = "80009000",
                    AddressType = EAddressType.MainProperty,
                }
            },
            Emails = new()
            {
                new()
                {
                    EmailType = EEmailType.Main,
                    Email = "Tester@test.com"
                }
            },
            Phones = new()
            {
                new()
                {
                    TelephoneType = ETelephoneType.CellPhone,
                    Ddi = "+55",
                    Ddd = "18",
                    PhoneNumber = "91177-6532"
                },
                new()
                {
                    TelephoneType = ETelephoneType.Landline,
                    Ddi = "+55",
                    Ddd = "18",
                    PhoneNumber = "3371-6532"
                }
            }
        };
        await _httpClient.PostAsJsonAsync(_endPointPostUrl, dtoRegisterOne);

        var dtoRegisterTwo = new ClientRegisterRequest
        {
            FullName = "Tester test",
            Addresses = new()
            {
                new()
                {
                    Country = "Country Two",
                    State = "SP",
                    City = "City Two",
                    Localization = "Localization Two",
                    District = "District Two",
                    Complement = "Complement Two",
                    Number = "185A",
                    ZipCode = "80009000",
                    AddressType = EAddressType.MainProperty,
                }
            },
            Emails = new()
            {
                new()
                {
                    EmailType = EEmailType.Main,
                    Email = "TesterTwo@test.com"
                }
            },
            Phones = new()
            {
                new()
                {
                    TelephoneType = ETelephoneType.CellPhone,
                    Ddi = "+55",
                    Ddd = "18",
                    PhoneNumber = "91177-2222"
                },
                new()
                {
                    TelephoneType = ETelephoneType.Landline,
                    Ddi = "+55",
                    Ddd = "18",
                    PhoneNumber = "3371-6532"
                }
            }
        };
        await _httpClient.PostAsJsonAsync(_endPointPostUrl, dtoRegisterTwo);

        var ExpectedStatusCodeResponse = HttpStatusCode.OK;
        var response = await _httpClient.GetAsync(_endPointGetUrl);
        var content = await response.Content.ReadAsStringAsync();
        var clientDtoResponse = JsonConvert.DeserializeObject<IEnumerable<ClientDataResponse>>(content);

        Assert.Equal(ExpectedStatusCodeResponse, response.StatusCode);
        Assert.NotEmpty(clientDtoResponse!);
    }


    [Fact]
    [Trait("OK", "Return empty list")]
    public async Task GetAllClientsAsync_ReturnEmptyList()
    {

        var ExpectedStatusCodeResponse = HttpStatusCode.OK;
        var response = await _httpClient.GetAsync(_endPointGetUrl);
        var content = await response.Content.ReadAsStringAsync();
        var clientDtoResponse = JsonConvert.DeserializeObject<IEnumerable<ClientDataResponse>>(content);

        Assert.Equal(ExpectedStatusCodeResponse, response.StatusCode);
        Assert.Empty(clientDtoResponse!);
    }



}
