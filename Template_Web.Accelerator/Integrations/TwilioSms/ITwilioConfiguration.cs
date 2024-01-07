namespace Template_Web.Accelerator.Integrations.TwilioSms
{
    public interface ITwilioConfiguration
    {
        public string AccountSid { get; set; }
        public string AuthToken { get; set; }
        public string PhoneNumber { get; set; }
    }
}
