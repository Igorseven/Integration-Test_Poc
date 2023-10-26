namespace UserRegistrationIntegrationTest.EndPoints.Settings;
public abstract class BaseIntegrationTest : IClassFixture<IntegrationTestWebAppFactory> 
{
    protected readonly HttpClient _httpClient;
    protected readonly IntegrationTestWebAppFactory _factory;
    private string _userId = "2";

    public BaseIntegrationTest(IntegrationTestWebAppFactory factory)
    {
        _factory = factory;
        _factory.DefaultUserId = _userId;
        _httpClient = _factory.CreateClient();
    }

    protected void SetUserId(string id) => _userId = id;
}
