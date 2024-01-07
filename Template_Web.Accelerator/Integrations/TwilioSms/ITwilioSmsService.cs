using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Template_Web.Accelerator.Integrations.TwilioSms
{
    public interface ITwilioSmsService
    {
        public Task<bool> SendSms(string recipient, string message);
    }
}
