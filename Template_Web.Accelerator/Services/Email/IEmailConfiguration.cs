namespace Template_Web.Accelerator.Services.Email
{
    public interface IEmailConfiguration
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string SmtpServer { get; set; }
        public int SmtpPort { get; set; }
    }
}
