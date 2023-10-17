namespace UserRegistrationIntegrationTest.EndPoints.Settings;
public abstract class BaseIntegrationTest<T> : IClassFixture<IntegrationTestWebAppFactory<T>> where T : class
{
    protected readonly HttpClient _httpClient;
    protected readonly IntegrationTestWebAppFactory<T> _factory;
    private string _userId = "2";

    public BaseIntegrationTest(IntegrationTestWebAppFactory<T> factory)
    {
        _factory = factory;
        _factory.DefaultUserId = _userId;
        _httpClient = _factory.CreateClient();
    }

    protected void SetUserid(string id) => _userId = id;
}
