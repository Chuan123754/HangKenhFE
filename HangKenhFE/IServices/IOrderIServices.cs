﻿using HangKenhFE.Models;
using HangKenhFE.Models.DTO;

namespace HangKenhFE.IServices
{
    public interface IOrderIServices
    {
        Task<List<Orders>> GetAll();
        Task<List<Orders>> GetOrderByIdAdmin(string idAdmin);
        Task<List<Orders>> GetOrderByIdUser(long idUser);
        Task<Orders> GetByIdOrders(long id);
        Task<Orders> OrdersAddress(long id);
        Task<Orders> Create(Orders orders);
        Task Update(Orders orders, long id);
        Task UpdateStrees(Orders orders, long id);
        Task UpdateStatus(Orders orders, long id);
        Task Delete(long id);
        Task<byte[]> ExportInvoice(long orderId);

        Task<MomoPaymentResponse> CreateMomoPaymentUrl(string fullName, decimal amount, string orderInfo);
        Task<MomoPaymentResponse> QueryPaymentStatus(string orderId);
        Task<int> GetTotal();
        Task<int> GetTotalToday();
        Task<decimal> GetTotalPiceToday();
        Task<decimal> GetTotalPiceWeek();
        Task<decimal> GetTotalPiceMonth();
        public Task<Dictionary<int, decimal>> GetTotalRevenuePerYear();
        public Task<Dictionary<string, int>> GetTotalMonth();

    }
}
