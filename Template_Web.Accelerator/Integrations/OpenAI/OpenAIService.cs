using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Template_Web.Accelerator.Integrations.OpenAI
{
    public class OpenAIService
    {
        private readonly ILogger<OpenAIService> _logger;
        private readonly IOpenAIConfiguration _openAIConfiguration;
        private readonly HttpClient _httpClient;
    }
}
