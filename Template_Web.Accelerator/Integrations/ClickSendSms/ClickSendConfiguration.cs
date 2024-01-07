using Microsoft.Extensions.Configuration;

namespace Template_Web.Accelerator.Integrations.ClickSendSms
{
    public class ClickSendConfiguration : IClickSendConfiguration
    {
        public string Username { get; set; }
        public string ApiKey { get; set; }

        public ClickSendConfiguration(IConfiguration configuration)
        {
            Username = configuration["ApplicationSettings:Integrations:Clicksend:Authentication:Username"];
            ApiKey = configuration["ApplicationSettings:Integrations:Clicksend:Authentication:ApiKey"];
        }
    }
}
