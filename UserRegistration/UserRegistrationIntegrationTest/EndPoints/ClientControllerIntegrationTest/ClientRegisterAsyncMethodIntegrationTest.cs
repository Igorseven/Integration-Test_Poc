﻿using System.Net;
using System.Net.Http.Json;
using UserRegistration.API.Business.ApplicationService.DataTransferObjects.Requests.ClientRequest;
using UserRegistration.API.Business.Domain.Entities;
using UserRegistration.API.Business.Domain.Enums;
using UserRegistrationIntegrationTest.EndPoints.Settings;

namespace UserRegistrationIntegrationTest.EndPoints.ClientControllerIntegrationTest;
public sealed class ClientRegisterAsyncMethodIntegrationTest : BaseIntegrationTest<Client>
{
    private const string _endPointUrl = "api/Client/register_client";

    public ClientRegisterAsyncMethodIntegrationTest(IntegrationTestWebAppFactory<Client> factory)
        : base(factory)
    {
        SetUserid("10");
    }

    [Fact]
    [Trait("OK", "Perfect setting")]
    public async Task ClientRegisterAsync_PerfectSetting_ReturnStatusCodeOK()
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

        var ExpectedResponse = HttpStatusCode.OK;

        var httpResponse = await _httpClient.PostAsJsonAsync(_endPointUrl, dtoRegister);

        Assert.Equal(ExpectedResponse, httpResponse.StatusCode);
    }


    [Fact]
    [Trait("BadRequest", "Invalid data")]
    public async Task ClientRegisterAsync_InvalidData_ReturnStatusCodeBadRequest()
    {
        var dtoRegister = new ClientRegisterRequest
        {
            FullName = "T",
            Addresses = new()
            {
                new()
                {
                    Country = "Country",
                    State = "SP",
                    City = "C",
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

        var ExpectedResponse = HttpStatusCode.BadRequest;

        var httpResponse = await _httpClient.PostAsJsonAsync(_endPointUrl, dtoRegister);

        Assert.Equal(ExpectedResponse, httpResponse.StatusCode);
    }


}
