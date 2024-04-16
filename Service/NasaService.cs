using RoverService.Models;
using Newtonsoft.Json;

namespace RoverService.Service
{
    public class NasaService :INasaService
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IConfiguration _configuration;

        public NasaService(IHttpClientFactory httpClientFactory, IConfiguration configuration)
        {
            _httpClientFactory = httpClientFactory;
            _configuration = configuration;
        }

        public async Task<PhotoDto?> GetPhotos(DateTime earthDate)
        {
            string apiKey = _configuration.GetSection("NasaApi")?.GetSection("ApiKey")?.Value ?? "";
            var httpClient = _httpClientFactory.CreateClient("NasaApi");
            var response = await httpClient.GetAsync($"/mars-photos/api/v1/rovers/curiosity/photos?earth_date={earthDate.ToString("yyyy-MM-dd")}&api_key={apiKey}");

            if (response != null)
            {                
               return JsonConvert.DeserializeObject<PhotoDto>(await response.Content.ReadAsStringAsync());               
            }
            else
            {
                return null;
            }
        }
    }
}
