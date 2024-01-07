using RestSharp;

namespace Template_Web.Accelerator.Integrations.ClickSendSms
{
    public class ClickSendSmsService : IClickSendSmsService
    {
        private readonly IClickSendConfiguration _clickSendConfiguration;

        public ClickSendSmsService(IClickSendConfiguration clickSendConfiguration)
        {
            _clickSendConfiguration = clickSendConfiguration;
        }

        private string Bearer
        {
            get
            {
                string credentials = $"{_clickSendConfiguration.Username}:{_clickSendConfiguration.ApiKey}";
                return $"Basic {Base64Encode(credentials)}";
            }
        }

        public async Task<bool> SendSmsAsync(ClickSendSmsModel requestModel)
        {
            try
            {
                ClickSendMessagesModel messages = new ClickSendMessagesModel()
                {
                    Messages = new List<ClickSendSmsModel>()
                    {
                        requestModel
                    }
                };

                var client = new RestClient("https://rest.clicksend.com/v3/sms/send");
                var request = new RestRequest();
                request.Method = Method.Post;
                request.AddHeader("Authorization", Bearer);
                request.AddHeader("Content-Type", "application/json");
                request.AddJsonBody(messages);
                var response = await client.ExecuteAsync(request);
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return false;
            }
        }

        public async Task<bool> SendMassSmsAsync(ClickSendMessagesModel messages)
        {
            try
            {
                var client = new RestClient("https://rest.clicksend.com/v3/sms/send");
                var request = new RestRequest();
                request.Method = Method.Post;
                request.AddHeader("Authorization", Bearer);
                request.AddHeader("Content-Type", "application/json");
                request.AddJsonBody(messages);
                var response = await client.ExecuteAsync(request);
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return false;
            }
        }

        private string Base64Encode(string plainText)
        {
            byte[] plainTextBytes = System.Text.Encoding.UTF8.GetBytes(plainText);
            string encodedString = Convert.ToBase64String(plainTextBytes);
            return encodedString;
        }
    }
}
