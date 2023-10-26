using Microsoft.AspNetCore.Authentication;

namespace UserRegistrationIntegrationTest.Settings;
public class TestAuthHandlerOptions : AuthenticationSchemeOptions
{
    public string DefaultUserId { get; set; } = null!;
}
