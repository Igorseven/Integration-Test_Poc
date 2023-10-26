using Newtonsoft.Json;
using System.Net;
using System.Net.Http.Json;
using UserRegistration.API.Business.ApplicationService.DataTransferObjects.Requests.ClientRequest;
using UserRegistration.API.Business.ApplicationService.DataTransferObjects.Responses.ClientResponse;
using UserRegistration.API.Business.Domain.Enums;
using UserRegistrationIntegrationTest.EndPoints.Settings;

namespace UserRegistrationIntegrationTest.EndPoints.ClientControllerIntegrationTest;
public sealed class GetClientWithEmailAndMainAddressAsyncMethodIntegrationTest : BaseIntegrationTest
{
    private const string _endPointGetUrl = "api/Client/get_client_with_email_and_main_address?clientId=";
    private const string _endPointPostUrl = "api/Client/register_client";

    public GetClientWithEmailAndMainAddressAsyncMethodIntegrationTest(IntegrationTestWebAppFactory factory) 
        : base(factory)
    {

    }


    [Fact]
    [Trait("OK", "Return dto with email and main address response")]
    public async Task GetClientWithEmailAndMainAddressAsync_ReturnClientWithEmailAndMainAddressResponse()
    {
        var dtoRegister = new ClientRegisterRequest
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
        await _httpClient.PostAsJsonAsync(_endPointPostUrl, dtoRegister);

        const string clientId = "1";
        var ExpectedStatusCodeResponse = HttpStatusCode.OK;
        var response = await _httpClient.GetAsync(_endPointGetUrl + clientId);
        var content = await response.Content.ReadAsStringAsync();
        var clientDtoResponse = JsonConvert.DeserializeObject<ClientWithEmailAndMainAddressResponse>(content);

        Assert.Equal(ExpectedStatusCodeResponse, response.StatusCode);
        Assert.NotNull(clientDtoResponse);
    }


    [Fact]
    [Trait("NoContent", "Return null")]
    public async Task GetClientWithEmailAndMainAddressAsync_ReturnNull()
    {

        const string clientId = "1";
        var ExpectedStatusCodeResponse = HttpStatusCode.NoContent;
        var response = await _httpClient.GetAsync(_endPointGetUrl + clientId);
        var content = await response.Content.ReadAsStringAsync();
        var clientDtoResponse = JsonConvert.DeserializeObject<ClientWithEmailAndMainAddressResponse>(content);

        Assert.Equal(ExpectedStatusCodeResponse, response.StatusCode);
        Assert.Null(clientDtoResponse);
    }
}
