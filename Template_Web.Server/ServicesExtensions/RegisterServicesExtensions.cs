using Template_Web.Accelerator.Services.Storage;
using Template_Web.Accelerator.Services.Security;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Template_Web.Accelerator.Builders;
using Template_Web.Accelerator.Services.Email;
using Template_Web.Accelerator.Integrations.TwilioSms;
using Template_Web.Accelerator.Integrations.ClickSendSms;
using Template_Web.Accelerator.Integrations.IP_API;
using Template_Web.Accelerator.Integrations.Disify;

namespace Template_Web.Server.ServicesExtensions
{
    public static class RegisterServicesExtensions
    {
        public static void RegisterServices(this IServiceCollection services)
        {
            services.AddScoped<LocalStorageService>();
            services.AddScoped<SessionStorageService>();
            services.AddScoped<CookieService>();
            services.AddScoped<AuthenticationProviderService>();
            services.AddScoped<UserContextBuilder>();

            services.AddSingleton<IEmailConfiguration, EmailConfiguration>();
            services.AddSingleton<IEmailService, EmailService>();

            //Extentions
            services.AddSingleton<ITwilioConfiguration, TwilioConfiguration>();
            services.AddSingleton<ITwilioSmsService, TwilioSmsService>();
            services.AddSingleton<IClickSendConfiguration, ClickSendConfiguration>();
            services.AddSingleton<IClickSendSmsService, ClickSendSmsService>();
            services.AddSingleton<IIPService, IPService>();
            services.AddSingleton<IDistifyService, DisifyService>();
        }
    }
}
