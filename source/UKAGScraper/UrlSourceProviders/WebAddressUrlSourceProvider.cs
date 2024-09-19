using UKAGScraper.UrlSourceProviders.Interfaces;

namespace UKAGScraper.UrlSourceProviders
{
    public class WebAddressUrlSourceProvider : IUrlSourceProvider<string>
    {
        private readonly HttpClient _httpClient;

        public WebAddressUrlSourceProvider(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<string> GetSourceAsync(string url)
        {
            string result = await _httpClient.GetStringAsync(url);

            return result;
        }
    }
}
