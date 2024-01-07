using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DetectLanguage;

namespace Template_Web.Accelerator.Integrations.DetectLanguage
{
    // Visit https://detectlanguage.com/ for more information and documentation on the DetectLanguage API.
    public class DetectLanguageService
    {
        private readonly IDetectLanguageConfiguration _detectLanguageConfiguration;
        private readonly DetectLanguageClient _client;

        public DetectLanguageService(IDetectLanguageConfiguration detectLanguageConfiguration)
        {
            _detectLanguageConfiguration = detectLanguageConfiguration;
            _client = new DetectLanguageClient(_detectLanguageConfiguration.ApiKey);
        }

        public async Task<DetectResult[]> DetectLanguagesAsync(string text)
        {
            DetectResult[] results = await _client.DetectAsync(text);
            return results;
        }

        public async Task<string> DetectLanguageAsync(string text)
        {
            string result = await _client.DetectCodeAsync(text);
            return result;
        }

        public async Task<DetectResult[][]> DetectBatchLanguagesAsync(string[] texts)
        {
            DetectResult[][] results = await _client.BatchDetectAsync(texts);
            return results;
        }

        public async Task<Language[]> GetSupportedLanguagesAsync()
        {
            Language[] languages = await _client.GetLanguagesAsync();
            return languages;
        }
    }
}
