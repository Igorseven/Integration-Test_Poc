using Microsoft.AspNetCore.Authentication;

namespace UserRegistrationIntegrationTest.EndPoints.Settings;
public class TestAuthHandlerOptions : AuthenticationSchemeOptions
{
    public string DefaultUserId { get; set; } = null!;
}
