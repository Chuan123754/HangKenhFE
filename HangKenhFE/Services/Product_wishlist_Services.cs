using HangKenhFE.IServices;
using HangKenhFE.Models;
using System.Drawing;

namespace HangKenhFE.Services
{
    public class Product_wishlist_Services : IProduct_wishlist_Services
    {
        private readonly HttpClient _httpClient;
        private readonly string _baseUrl;
        public Product_wishlist_Services(IConfiguration configuration)
        {
            _httpClient = new HttpClient();
            _baseUrl = configuration.GetValue<string>("ApiSettings:BaseUrl");
        }
        public async Task Create(Product_wishlist pw)
        {
            await _httpClient.PostAsJsonAsync($"{_baseUrl}/api/ProductAttribute_wishlist_/CreateWLP", pw);
        }

        public async Task Delete(long id)
        {
            var response = await _httpClient.DeleteAsync($"{_baseUrl}/api/ProductAttribute_wishlist_/DeletePWL?id={id}").ConfigureAwait(false);
            if (!response.IsSuccessStatusCode)
            {
                var error = await response.Content.ReadAsStringAsync();
                Console.WriteLine($"API Error: {error}");
                throw new Exception($"Failed to delete ProductAttribute_wishlist with ID {id}: {error}");
            }
        }

        public async Task<List<Product_wishlist>> GetAllPW()
        {
            var response = await _httpClient.GetAsync($"{_baseUrl}/api/ProductAttribute_wishlist_/GetAllWLP").ConfigureAwait(false);
            if (!response.IsSuccessStatusCode)
            {
                var error = await response.Content.ReadAsStringAsync();
                Console.WriteLine($"API Error: {error}");
                throw new Exception("Failed to get all Product_variants_wishlist.");
            }

            return await response.Content.ReadFromJsonAsync<List<Product_wishlist>>();
        }

        public async Task<Product_wishlist> GetByID(long id)
        {
            var response = await _httpClient.GetAsync($"{_baseUrl}/api/ProductAttribute_wishlist_/GetWLPById?id={id}").ConfigureAwait(false);
            if (!response.IsSuccessStatusCode)
            {
                var error = await response.Content.ReadAsStringAsync();
                Console.WriteLine($"API Error: {error}");
                throw new Exception($"Failed to get details of Product_variants_wishlist with ID {id}: {error}");
            }

            return await response.Content.ReadFromJsonAsync<Product_wishlist>(); throw new NotImplementedException();
        }
    }
}
