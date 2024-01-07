using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Template_Web.Accelerator.Integrations.DetectLanguage
{
    public class DetectLanguageConfiguration : IDetectLanguageConfiguration
    {
        public string ApiKey { get; set; }

        public DetectLanguageConfiguration(IConfiguration configuration)
        {
            ApiKey = configuration["ApplicationSettings:Integrations:DetectLanguage:Authentication:ApiKey"];
        }
    }
}
