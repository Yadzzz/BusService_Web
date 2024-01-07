using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestSharp;

namespace Template_Web.Accelerator.Integrations.IP_API
{
    public class IPService : IIPService
    {
        public async Task<IPModel> GetIPInfoAsync(string ip)
        {
            var client = new RestClient($"http://ip-api.com/json/{ip}");
            var request = new RestRequest();
            request.Method = Method.Get;
            RestResponse response = await client.ExecuteAsync(request);
            IPModel ipModel = Newtonsoft.Json.JsonConvert.DeserializeObject<IPModel>(response.Content);
            return ipModel;
        }
    }
}
