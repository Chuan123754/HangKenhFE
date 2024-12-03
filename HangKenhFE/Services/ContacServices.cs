using HangKenhFE.IServices;
using HangKenhFE.Models;

namespace ViewsFE.Services
{
    public class ContacServices : IContacServices
    {
        private readonly HttpClient _httpClient;
        private readonly string _baseUrl;
        public ContacServices(IConfiguration configuration)
        {
            _httpClient = new HttpClient();
            _baseUrl = configuration.GetValue<string>("ApiSettings:BaseUrl");
        }
        public async Task Create(Contact c)
        {
            await _httpClient.PostAsJsonAsync($"{_baseUrl}/api/Contact/CreateContact", c);
        }     
    }
}
