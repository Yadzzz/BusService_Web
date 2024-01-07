using Microsoft.Extensions.Configuration;

namespace Template_Web.Accelerator.Integrations.TwilioSms
{
    public class TwilioConfiguration : ITwilioConfiguration
    {
        public string AccountSid { get; set; }
        public string AuthToken { get; set; }
        public string PhoneNumber { get; set; }

        public TwilioConfiguration(IConfiguration configuration)
        {
            AccountSid = configuration["ApplicationSettings:Integrations:Twilio:Authentication:AccountSid"];
            AuthToken = configuration["ApplicationSettings:Integrations:Twilio:Authentication:AuthToken"];
            PhoneNumber = configuration["ApplicationSettings:Integrations:Twilio:Authentication:PhoneNumber"];
        }
    }
}
