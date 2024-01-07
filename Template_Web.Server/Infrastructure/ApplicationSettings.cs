namespace Template_Web.Server.Infrastructure
{
    public class ApplicationSettings
    {
        public JwtSettings JwtSettings { get; set; }
        public EmailConfiguration EmailConfiguration { get; set; }
        public Integrations Integrations { get; set; }
    }

    public class JwtSettings
    {
        public string SecretKey { get; set; }
        public string Issuer { get; set; }
        public string Audience { get; set; }
    }

    public class EmailConfiguration
    {
        public string SmtpServer { get; set; }
        public int SmtpPort { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }

    public class Integrations
    {
        public Twilio Twilio { get; set; }
        public ClickSend ClickSend { get; set; }
        public DetectLanguage DetectLanguage { get; set; }
        public OpenAI OpenAI { get; set; }
    }

    public class Twilio
    {
        public TwilioAuthentication Authentication { get; set; }
    }

    public class TwilioAuthentication
    {
        public string AccountSid { get; set; }
        public string AuthToken { get; set; }
        public string PhoneNumber { get; set; }
    }

    public class ClickSend
    {
        public ClickSendAuthentication Authentication { get; set; }
    }

    public class ClickSendAuthentication
    {
        public string Username { get; set; }
        public string ApiKey { get; set; }
    }

    public class DetectLanguage
    {
        public DetectLanguageAuthentication Authentication { get; set; }
    }

    public class DetectLanguageAuthentication
    {
        public string ApiKey { get; set; }
    }

    public class OpenAI
    {
        public OpenAIAuthentication Authentication { get; set; }
    }

    public class OpenAIAuthentication
    {
        public string ApiKey { get; set; }
    }

}
