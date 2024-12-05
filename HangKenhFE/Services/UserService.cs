﻿using HangKenhFE.IServices;
using HangKenhFE.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.JSInterop;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Net.Http.Json;
using System.Text.Json;

namespace HangKenhFE.Services
{
    public class UserService : IUserService
    {
        private readonly HttpClient _httpClient;

        public UserService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<Users>> GetAll()
        {
            string requestURL = "https://localhost:7011/api/Users/Users-get";
            var response = await _httpClient.GetStringAsync(requestURL);
            return JsonConvert.DeserializeObject<List<Users>>(response);
        }

        public async Task<Users> GetById(long id)
        {
            string requestURL = $"https://localhost:7011/api/Users/Users-get-id?id={id}";
            var response = await _httpClient.GetStringAsync(requestURL);
            return JsonConvert.DeserializeObject<Users>(response);
        }

        public async Task<Users> Create(Users user)
        {
            user.Created_at = DateTime.Now;
            user.Updated_at = DateTime.Now;

            // Kiểm tra trùng lặp email
            if (!string.IsNullOrWhiteSpace(user.Email) && await IsEmailExists(user.Email))
            {
                throw new Exception("Email đã tồn tại.");
            }
            string userRequestURL = "https://localhost:7011/api/Users/Users-post";
            var userJsonContent = JsonConvert.SerializeObject(user);
            var userContent = new StringContent(userJsonContent, Encoding.UTF8, "application/json");
            var userResponse = await _httpClient.PostAsync(userRequestURL, userContent);

            if (!userResponse.IsSuccessStatusCode)
            {
                var errorContent = await userResponse.Content.ReadAsStringAsync();
                throw new Exception($"API call failed with status code {userResponse.StatusCode} and message: {errorContent}");
            }

            var createdUserJson = await userResponse.Content.ReadAsStringAsync();
            var createdUser = JsonConvert.DeserializeObject<Users>(createdUserJson);

            if (createdUser == null)
            {
                throw new Exception("Không thể lấy được người dùng vừa tạo.");
            }

            // Tạo giỏ hàng cho người dùng mới
            var cart = new Carts
            {
                Id = 0,
                UserId = createdUser.Id,
                Status = "New",
                Description = "Giỏ hàng mặc định"
            };

            string cartRequestURL = "https://localhost:7011/api/Carts/carts-post";
            var cartJsonContent = JsonConvert.SerializeObject(cart);
            var cartContent = new StringContent(cartJsonContent, Encoding.UTF8, "application/json");
            var cartResponse = await _httpClient.PostAsync(cartRequestURL, cartContent);

            if (!cartResponse.IsSuccessStatusCode)
            {
                var errorContent = await cartResponse.Content.ReadAsStringAsync();
                throw new Exception($"API call failed with status code {cartResponse.StatusCode} and message: {errorContent}");
            }

            // Trả về đối tượng người dùng vừa được tạo
            return createdUser;
        }


        public async Task Update(Users user)
        {
            string requestURL = "https://localhost:7011/api/Users/Users-put";
            var jsonContent = JsonConvert.SerializeObject(user);
            var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");
            await _httpClient.PutAsync(requestURL, content);
        }

        public async Task Delete(long id)
        {
            string requestURL = $"https://localhost:7011/api/Users/Users-delete?id={id}";
            await _httpClient.DeleteAsync(requestURL);
        }


        public async Task<bool> IsEmailExists(string email)
        {
            try
            {
                string requestURL = $"https://localhost:7011/api/Users/Users-get-email?email={email}";
                var response = await _httpClient.GetStringAsync(requestURL);
                var user = JsonConvert.DeserializeObject<Users>(response);
                return user != null;
            }
            catch (HttpRequestException ex) when (ex.StatusCode == System.Net.HttpStatusCode.NotFound)
            {
                return false;
            }
        }

        public async Task<bool> IsPhoneExists(string phone)
        {
            try
            {
                string requestURL = $"https://localhost:7011/api/Users/Users-get-phone?phone={phone}";
                var response = await _httpClient.GetStringAsync(requestURL);
                var user = JsonConvert.DeserializeObject<Users>(response);
                return user != null;
            }
            catch (HttpRequestException ex) when (ex.StatusCode == System.Net.HttpStatusCode.NotFound)
            {
                return false;
            }
        }
        public async Task Register(Users user)
        {
            var response = await _httpClient.PostAsJsonAsync("https://localhost:7011/api/Users/register", user);

            if (!response.IsSuccessStatusCode)
            {
                var errorMessage = await response.Content.ReadAsStringAsync();
                throw new Exception($"Đăng ký thất bại: {errorMessage}");
            }
        }

        public async Task<Users> Login(Users user)
        {
            var response = await _httpClient.PostAsJsonAsync("https://localhost:7011/api/Users/login", user);

            if (!response.IsSuccessStatusCode)
            {
                var errorMessage = await response.Content.ReadAsStringAsync();
                throw new Exception($"Đăng nhập thất bại: {errorMessage}");
            }

            var rawContent = await response.Content.ReadAsStringAsync();
            Console.WriteLine($"JSON trả về từ API: {rawContent}");

            if (rawContent.StartsWith("\"") && rawContent.EndsWith("\""))
            {
                var jsonString = Newtonsoft.Json.JsonConvert.DeserializeObject<string>(rawContent);
                var userResponse = Newtonsoft.Json.JsonConvert.DeserializeObject<Users>(jsonString);
                if (userResponse == null)
                {
                    throw new Exception("Không thể đọc dữ liệu trả về từ API.");
                }

                return userResponse;
            }
            else
            {
                // Trường hợp bình thường, deserialize trực tiếp
                var userResponse = Newtonsoft.Json.JsonConvert.DeserializeObject<Users>(rawContent);

                if (userResponse == null)
                {
                    throw new Exception("Không thể đọc dữ liệu trả về từ API.");
                }

                return userResponse;
            }
        }



        public class ResponseLogin
        {
            public string Message { get; set; }
            public Users User { get; set; }
        }


        //public async Task Logout(long idUser)
        //{
        //    await _httpClient.PostAsJsonAsync($"https://localhost:7011/api/Users/logout?userId={idUser}");
        //}
        public async Task Logout(long idUser)
        {
            var response = await _httpClient.PostAsJsonAsync($"https://localhost:7011/api/Users/logout?userId={idUser}", new { });

            if (!response.IsSuccessStatusCode)
            {
                var errorMessage = await response.Content.ReadAsStringAsync();
                throw new Exception($"Đăng xuất thất bại: {errorMessage}");
            }
        }
    }
}
