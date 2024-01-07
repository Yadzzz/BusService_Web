using Template_Web.Server.Infrastructure;

namespace Template_Web.Server.ServicesExtensions
{
    public static class ApplicationExtensions
    {
        public static void ConfigureApplication(this WebApplicationBuilder builder, IConfiguration configuration)
        {
            builder.Services.Configure<ApplicationSettings>(configuration.GetSection("ApplicationSettings"));
        }
    }
}
