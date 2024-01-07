using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Template_Web.Accelerator.Integrations.Disify
{
    //Visit https://www.disify.com/ for more information
    public class DisifyService : IDistifyService
    {
        public DisifyService()
        {
            
        }

        public async Task<bool> ValidateEmail(string email)
        {
            var client = new RestClient("https://www.disify.com/api/email");
            var request = new RestRequest();
            request.Method = Method.Post;
            request.AddParameter("email", email);

            RestResponse response = await client.ExecuteAsync(request);
            var DisifyResponse = Newtonsoft.Json.JsonConvert.DeserializeObject<DisifyEmailValidationResponse>(response.Content);

            return DisifyResponse.Format && DisifyResponse.Dns && !DisifyResponse.Disposable;
        }

        public async Task<DisifyEmailValidationResponse> ValidateEmailDetailed(string email)
        {
            var client = new RestClient("https://www.disify.com/api/email");
            var request = new RestRequest();
            request.Method = Method.Post;
            request.AddParameter("email", email);

            RestResponse response = await client.ExecuteAsync(request);
            var DisifyResponse = Newtonsoft.Json.JsonConvert.DeserializeObject<DisifyEmailValidationResponse>(response.Content);

            return DisifyResponse;
        }
    }
}
