using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Template_Web.Accelerator.Integrations.OpenAI
{
    public interface IOpenAIConfiguration
    {
        public string ApiKey { get; set; }
    }
}
