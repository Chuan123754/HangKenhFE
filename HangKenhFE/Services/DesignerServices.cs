using Newtonsoft.Json;
using HangKenhFE.IServices;
using HangKenhFE.Models;

namespace HangKenhFE.Services
{
    public class DesignerServices : IDesignerServices
    {
        private readonly HttpClient _httpClient;
        private readonly string _baseUrl;
        public DesignerServices(IConfiguration configuration)
        {
            _httpClient = new HttpClient();
            _baseUrl = configuration.GetValue<string>("ApiSettings:BaseUrl");
        }   

        public async Task<List<Designer>> GetAll()
        {
            string requestURL = $"{_baseUrl}/api/Designer";
            return await _httpClient.GetFromJsonAsync<List<Designer>>(requestURL);
        }

        public async Task<Designer> GetById(long id)
        {
            return await _httpClient.GetFromJsonAsync<Designer>($"{_baseUrl}/api/Designer/{id}");
        }

        public async Task<List<Designer>> GetByTypeAsyncClient(int pageNumber, int pageSize, string searchTerm)
        {
            var uri = $"{_baseUrl}/api/Designer/get-by-type-client?pageNumber={pageNumber}&pageSize={pageSize}&searchTerm={Uri.EscapeDataString(searchTerm)}";
            return await _httpClient.GetFromJsonAsync<List<Designer>>(uri);
        }

        public async Task<int> GetTotalCountAsyncClient(string searchTerm)
        {
            var url = $"{_baseUrl}/api/Designer/Get-Total-Count-Client?searchTerm={Uri.EscapeDataString(searchTerm)}";

            // Gọi API và nhận tổng số lượng bài viết
            var response = await _httpClient.GetAsync(url);
            response.EnsureSuccessStatusCode(); // Kiểm tra xem phản hồi có thành công hay không

            var count = await response.Content.ReadFromJsonAsync<int>();
            return count;
        }
    }
}
