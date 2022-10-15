using Diploma.IdentityServer.Configurations;
using Diploma.IdentityServer.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services
    .AddIdentityServer()
    .AddDeveloperSigningCredential()
    .AddInMemoryApiResources(IdentityServerConfig.ApiResources())
    .AddInMemoryClients(IdentityServerConfig.Clients())
    .AddResourceOwnerValidator<UserValidator>()
    .AddInMemoryIdentityResources(IdentityServerConfig.IdentityResources());

var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.Run();
