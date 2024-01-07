using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Template_Web.Accelerator.Services.Security;
using Template_Web.Accelerator.Services.Storage;
using System.Text;

namespace Template_Web.Server.ServicesExtensions
{
    public static class RegisterJwtExtensions
    {
        public static void RegisterJwtServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<JwtSettings>(configuration.GetSection("ApplicationSettings:JwtSettings"));
            services.AddScoped(provider =>
            {
                var jwtSettings = provider.GetRequiredService<IOptions<JwtSettings>>().Value;
                return new JwtService(jwtSettings.SecretKey, jwtSettings.Issuer, jwtSettings.Audience);
            });

            var jwtSettings = configuration.GetSection("ApplicationSettings:JwtSettings").Get<JwtSettings>();

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.RequireHttpsMetadata = false; // Set to true in a production environment
                    options.SaveToken = true;
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidIssuer = jwtSettings.Issuer,
                        ValidateAudience = true,
                        ValidAudience = jwtSettings.Audience,
                        ValidateLifetime = true,
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings.SecretKey)),
                        ValidateIssuerSigningKey = true,
                    };
                });

            //services.AddAuthorization(options =>
            //{
            //    options.AddPolicy("AdminPolicy", policy =>
            //    {
            //        policy.RequireRole("Admin"); // This policy requires the "Admin" role.
            //    });
            //});
        }
    }
}
