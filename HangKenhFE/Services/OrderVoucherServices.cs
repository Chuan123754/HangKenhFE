﻿using HangKenhFE.IServices;
using HangKenhFE.Models;
using Newtonsoft.Json;
using System.Text;

namespace HangKenhFE.Services
{
    public class OrderVoucherServices :IOrderVoucherServices
    {
        private readonly HttpClient _httpClient;
        private readonly string _baseUrl;

        public OrderVoucherServices(HttpClient httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient;
            _baseUrl = configuration.GetValue<string>("ApiSettings:BaseUrl");
        }

        public async Task<bool> Create(Order_Vouchers order_Voucher)
        {
            string requestURL = $"{_baseUrl}/api/OrderVouchers/Create";
            var jsonContent = JsonConvert.SerializeObject(order_Voucher);
            var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync(requestURL, content);
            if (!response.IsSuccessStatusCode)
            {
                var errorContent = await response.Content.ReadAsStringAsync();
                throw new HttpRequestException($"Failed to create UserVoucher. Status Code: {response.StatusCode}, Reason: {response.ReasonPhrase}, Content: {errorContent}");
            }
            return response.IsSuccessStatusCode;
        }

        public async Task GetByVoucherIdAndOrderId(long orderId, long voucherId)
        {
            await _httpClient.GetStringAsync($"https://localhost:7011/api/OrderVouchers/GetByIdOrderAndIdVoucher?idOrder={orderId}&idVoucher={voucherId}");
        }
        public async Task<List<Order_Vouchers>> GetAll()
        {
            string requestURL = "https://localhost:7011/api/OrderVouchers";
            var response = await _httpClient.GetStringAsync(requestURL);
            var orderVouchers = JsonConvert.DeserializeObject<List<Order_Vouchers>>(response);
            return orderVouchers;
        }
    }
}
