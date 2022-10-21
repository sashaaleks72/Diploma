using Diploma.IdentityServer.Configurations;
using Diploma.IdentityServer.DB;
using Diploma.IdentityServer.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// var webApi = builder.Configuration["WebApiHost"];
var server = builder.Configuration["DBServer"];
var port = builder.Configuration["DBPort"];
var user = builder.Configuration["DBUser"];
var pass = builder.Configuration["DBPassword"];
var database = builder.Configuration["DBName"];

string connectionString = string.Empty;

if (server != null)
    connectionString = $"Server={server},{port};Initial Catalog={database};User ID={user};Password={pass}";
else connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddControllers();
builder.Services.AddDbContext<UserDbContext>(options => options.UseLazyLoadingProxies().UseSqlServer(connectionString));

builder.Services
    .AddIdentityServer()
    .AddDeveloperSigningCredential()
    .AddInMemoryApiResources(IdentityServerConfig.ApiResources())
    .AddInMemoryClients(IdentityServerConfig.Clients())
    .AddResourceOwnerValidator<UserValidator>()
    .AddInMemoryIdentityResources(IdentityServerConfig.IdentityResources());

var app = builder.Build();

app.UseIdentityServer();
app.Run();
