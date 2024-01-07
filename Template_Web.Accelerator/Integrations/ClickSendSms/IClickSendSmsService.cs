using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Template_Web.Accelerator.Integrations.ClickSendSms
{
    public interface IClickSendSmsService
    {
        public Task<bool> SendSmsAsync(ClickSendSmsModel requestModel);
        public Task<bool> SendMassSmsAsync(ClickSendMessagesModel messages);
    }
}
