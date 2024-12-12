using HangKenhFE.IServices;
using HangKenhFE.Models;
using HangKenhFE.Pages.Client;
using Newtonsoft.Json;
using System.Text;

namespace HangKenhFE.Services
{
    public class WishlistServices : IWishlistServices
    {
        private readonly HttpClient _httpClient;
        private readonly string _baseUrl;
        public WishlistServices(HttpClient httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient;
            _baseUrl = configuration.GetValue<string>("ApiSettings:BaseUrl");
        }
        private async Task<Users> GetUserById(long userId)
        {
            string userRequestUrl = $"{_baseUrl}/api/Users/Users-get-id?id={userId}";
            var userResponse = await _httpClient.GetAsync(userRequestUrl);

            if (!userResponse.IsSuccessStatusCode)
            {
                throw new Exception("Người dùng không tồn tại.");
            }

            var userJson = await userResponse.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<Users>(userJson);
        }

        public async Task Create(Wishlist wl)
        {
            var user = await GetUserById(wl.Users.Id);

            var wlToSend = new
            {
                Id = wl.Id,
                Users = new
                {
                    Id = user.Id,
                    Name = user.Name,
                    Phone = user.Phone,
                    Email = user.Email,
                    Password = user.Password,
                    RememberToken = user.RememberToken,
                    Address = user.Address,
                    CreatedAt = user.Created_at,
                    UpdatedAt = user.Updated_at
                },
                CreatedAt = DateTime.UtcNow.ToString("yyyy-MM-ddTHH:mm:ss.fffZ"),
                UpdatedAt = DateTime.UtcNow.ToString("yyyy-MM-ddTHH:mm:ss.fffZ")
            };

            string jsonContent = JsonConvert.SerializeObject(wlToSend);

            string requestURL = $"{_baseUrl}/api/Wishlist/wishlist-post";
            var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync(requestURL, content);
            if (!response.IsSuccessStatusCode)
            {
                var errorContent = await response.Content.ReadAsStringAsync();
                throw new Exception($"Wishlist thất bại với mã trạng thái {response.StatusCode} và thông điệp: {errorContent}");
            }
        }

        public async Task Delete(long id)
        {
            string requestURL = $"{_baseUrl}/api/Wishlist/wishlist-delete?id={id}";
            var response = await _httpClient.DeleteAsync(requestURL);
            if (!response.IsSuccessStatusCode)
            {
                throw new Exception($"Xóa giỏ hàng thất bại với mã trạng thái {response.StatusCode}");
            }
        }

        public async Task<List<Wishlist>> GetAll()
        {
            string requestURL = $"{_baseUrl}/api/Wishlist/wishlist-get";
            var response = await _httpClient.GetStringAsync(requestURL);
            return JsonConvert.DeserializeObject<List<Wishlist>>(response);
        }

        public async Task<Wishlist> GetById(long id)
        {
            string requestURL = $"{_baseUrl}/api/Wishlist/wishlist-get-id?id={id}";
            var response = await _httpClient.GetStringAsync(requestURL);
            return JsonConvert.DeserializeObject<Wishlist>(response);
        }

        public async Task Update(Wishlist wl)
        {
            var user = await GetUserById(wl.Users.Id);

            var wlToSend = new
            {
                Id = wl.Id,
                Users = new
                {
                    Id = user.Id,
                    Name = user.Name,
                    Phone = user.Phone,
                    Email = user.Email,
                    Password = user.Password,
                    RememberToken = user.RememberToken,
                    Address = user.Address,
                    CreatedAt = user.Created_at,
                    UpdatedAt = user.Updated_at
                },
                CreatedAt = DateTime.UtcNow.ToString("yyyy-MM-ddTHH:mm:ss.fffZ"),
                UpdatedAt = DateTime.UtcNow.ToString("yyyy-MM-ddTHH:mm:ss.fffZ")
            };

            string jsonContent = JsonConvert.SerializeObject(wlToSend);

            string requestURL = $"{_baseUrl}/api/Wishlist/wishlist-put";
            var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");

            var response = await _httpClient.PutAsync(requestURL, content);
            if (!response.IsSuccessStatusCode)
            {
                var errorContent = await response.Content.ReadAsStringAsync();
                throw new Exception($"Cập nhật wishlist thất bại với mã trạng thái {response.StatusCode} và thông điệp: {errorContent}");
            }
        }
    }
}
