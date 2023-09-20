using UserRegistration.API.Settings;
using UserRegistration.API.Settings.Configurations;

var builder = WebApplication.CreateBuilder(args);
IConfiguration configuration = builder.Configuration;

builder.Services.AddSettingsConfigurations(configuration);
builder.Services.AddEndpointsApiExplorer();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors("DfPolicy");
app.UseAuthentication();
app.UseAuthorization();
app.MigrateDatabase();
app.MapControllers();

app.Run();
