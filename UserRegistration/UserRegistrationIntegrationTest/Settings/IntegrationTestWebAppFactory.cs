using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Testcontainers.MsSql;
using UserRegistration.API.Business.Insfrastructure.ORM.Context;

namespace UserRegistrationIntegrationTest.Settings;
public class IntegrationTestWebAppFactory : WebApplicationFactory<Program>, IAsyncLifetime
{
    public string DefaultUserId { get; set; } = "1";
    private readonly MsSqlContainer _dbContainer = new MsSqlBuilder().WithImage("mcr.microsoft.com/mssql/server:2019-latest")
                                                                     .WithEnvironment("-e", "MSSQL_PID=Express")
                                                                     .WithPassword("test@2023")
                                                                     .Build();

    public IntegrationTestWebAppFactory()
    {
    }

    protected override void ConfigureWebHost(IWebHostBuilder builder)
    {
        base.ConfigureWebHost(builder);

        builder.ConfigureTestServices(services =>
        {

            services.Configure<TestAuthHandlerOptions>(options => options.DefaultUserId = DefaultUserId);

            services.AddAuthentication(TestAuthHandler.AuthenticationScheme)
                    .AddScheme<TestAuthHandlerOptions, TestAuthHandler>(TestAuthHandler.AuthenticationScheme, options => { });

            services.RemoveAll(typeof(DbContextOptions<ApplicationContext>));

            services.AddDbContext<ApplicationContext>(options =>
            {
                options.UseSqlServer(_dbContainer.GetConnectionString());
            });
        });
    }

    public async Task InitializeAsync()
    {
        await _dbContainer.StartAsync();

        using var scope = Services.CreateScope();

        var scopeServices = scope.ServiceProvider;

        var context = scopeServices.GetRequiredService<ApplicationContext>();

        await context.Database.EnsureCreatedAsync();
    }

    public new async Task DisposeAsync() => await _dbContainer.StopAsync();
}
