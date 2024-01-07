using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Template_Web.Accelerator.Integrations.Disify
{
    public interface IDistifyService
    {
        public Task<bool> ValidateEmail(string email);
        public Task<DisifyEmailValidationResponse> ValidateEmailDetailed(string email);
    }
}
