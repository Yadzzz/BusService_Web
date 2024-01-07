using Microsoft.AspNetCore.DataProtection.KeyManagement;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Template_Web.Accelerator.Integrations.OpenAI
{
    public class OpenAIConfiguration : IOpenAIConfiguration
    {
        public string ApiKey { get; set; }

        public OpenAIConfiguration(IConfiguration configuration)
        {
            ApiKey = configuration["ApplicationSettings:Integrations:OpenAI:Authentication:ApiKey"];
        }
    }
}
