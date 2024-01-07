using Twilio;
using Twilio.Rest.Api.V2010.Account;

namespace Template_Web.Accelerator.Integrations.TwilioSms
{
    // Check Twilio Documentation for more information on how to setup your account and get the required information for this class to work properly
    // https://www.twilio.com/docs/sms/quickstart/csharp-dotnet-core
    public class TwilioSmsService : ITwilioSmsService
    {
        private readonly ITwilioConfiguration _twilioConfiguration;

        public TwilioSmsService(ITwilioConfiguration twilioConfiguration)
        {
            _twilioConfiguration = twilioConfiguration;
        }

        public async Task<bool> SendSms(string recipient, string message)
        {
            try
            {
                TwilioClient.Init(_twilioConfiguration.AccountSid, _twilioConfiguration.AuthToken);

                var smsMessage = await MessageResource.CreateAsync(
                    body: message,
                    from: new Twilio.Types.PhoneNumber(_twilioConfiguration.PhoneNumber),
                    to: new Twilio.Types.PhoneNumber(recipient)
                );

                if (smsMessage.ErrorCode != null)
                {
                    return false;
                }

                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }
    }
}
