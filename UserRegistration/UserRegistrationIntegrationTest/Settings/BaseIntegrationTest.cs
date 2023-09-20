namespace UserRegistrationIntegrationTest.Settings;
public abstract class BaseIntegrationTest<T> : IClassFixture<IntegrationTestWebAppFactory<T>> where T : class
{
    protected readonly HttpClient _client;
    protected readonly IntegrationTestWebAppFactory<T> _factory;

    public BaseIntegrationTest(IntegrationTestWebAppFactory<T> factory)
    {
        _factory = factory;
        _client = _factory.CreateClient();
    }
}
