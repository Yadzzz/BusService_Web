using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Template_Web.Accelerator.Integrations.Disify
{
    public class DisifyEmailValidationResponse
    {
        public bool Format { get; set; }
        public string Domain { get; set; }
        public bool Disposable { get; set; }
        public bool Dns { get; set; }
    }
}
