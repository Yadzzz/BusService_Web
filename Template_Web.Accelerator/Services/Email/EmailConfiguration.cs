using Microsoft.Extensions.Configuration;

namespace Template_Web.Accelerator.Services.Email
{
    public class EmailConfiguration : IEmailConfiguration
    {
        public string SmtpServer { get; set; }
        public int SmtpPort { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public EmailConfiguration(IConfiguration configuration)
        {
            SmtpServer = configuration["ApplicationSettings:EmailConfiguration:SmtpServer"];
            SmtpPort = int.Parse(configuration["ApplicationSettings:EmailConfiguration:SmtpPort"]);
            Email = configuration["ApplicationSettings:EmailConfiguration:Email"];
            Password = configuration["ApplicationSettings:EmailConfiguration:Password"];
        }
    }
}
