using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Diploma.DB;
using Diploma.Interfaces;
using Diploma.Providers;
using Diploma.Services;
using System;
using System.Collections.Generic;

namespace Diploma
{
    public class Startup
    {
        private readonly string _myAllowSpecificOrigins;

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;

            _myAllowSpecificOrigins = "_myAllowSpecificOrigins";
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            var server = Configuration["DBServer"];
            var port = Configuration["DBPort"];
            var user = Configuration["DBUser"];
            var pass = Configuration["DBPassword"];
            var database = Configuration["DBName"];

            string connectionString = string.Empty;

            if (server != null)
                connectionString = $"Server={server},{port};Initial Catalog={database};User ID={user};Password={pass}";
            else connectionString = Configuration.GetConnectionString("DefaultConnection");

            services.AddCors(options =>
            {
                options.AddPolicy(name: _myAllowSpecificOrigins,
                                  policy =>
                                  {
                                      policy.WithOrigins("http://localhost:3000")
                                      .AllowAnyMethod()
                                      .AllowAnyHeader();
                                  });
            });
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(JwtBearerDefaults.AuthenticationScheme, options =>
                {
                    options.Authority = "http://host.docker.internal:44382";
                    options.RequireHttpsMetadata = false;
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateAudience = false
                    };
                });
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseLazyLoadingProxies().UseSqlServer(connectionString));
            services.AddControllers();
            services.AddTransient<IProductsDataProvider, ProductsDataProvider>();
            services.AddTransient<IProductService, ProductService>();
            services.AddTransient<ICatalogDataProvider, CatalogDataProvider>();
            services.AddTransient<ICatalogService, CatalogService>();
            services.AddTransient<IOrderDataProvider, OrderDataProvider>();
            services.AddTransient<IOrderService, OrderService>();
            services.AddTransient<IUserDataProvider, UserDataProvider>();
            services.AddTransient<IRoleDataProvider, RoleDataProvider>();
            services.AddTransient<IUserService, UserService>();
            services.AddAutoMapper(typeof(Startup));
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Diploma", Version = "v1" });
                c.AddSecurityDefinition("oauth2", new OpenApiSecurityScheme
                {
                    Type = SecuritySchemeType.OAuth2,
                    Flows = new OpenApiOAuthFlows
                    {
                        Password = new OpenApiOAuthFlow
                        {
                            TokenUrl = new Uri("http://host.docker.internal:44382/connect/token")
                        }
                    }
                });
                c.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "oauth2"
                            },
                            Scheme = "oauth2",
                            Name = "Bearer",
                            In = ParameterLocation.Header
                        },
                        new List<string>()
                    }
                });
            });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Diploma v1");
                    c.OAuthClientId("swagger_login");
                    c.OAuthClientSecret("swagger_pass");
                });
            }

            app.UseRouting();

            app.UseCors(_myAllowSpecificOrigins);

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
