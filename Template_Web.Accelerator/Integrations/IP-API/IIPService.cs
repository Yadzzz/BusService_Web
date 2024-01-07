using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Template_Web.Accelerator.Integrations.IP_API
{
    public interface IIPService
    {
        public Task<IPModel> GetIPInfoAsync(string ip);
    }
}
