﻿using HangKenhFE.Models;

namespace HangKenhFE.IServices
{
    public interface OrderDetailsIServices
    {
        Task<List<Order_details>> GetAlldetail();
        Task<Order_details> GetByIdOrderdetails(long id);
        Task<Order_details> GetByOrderIdAndProductAttributeId(long orderId, long productAttributeId);
        Task<List<Order_details>> GetOrderDetailsByOrderId(long idOrder);
        Task Create(Order_details orderdetails);
        Task Update(Order_details orderdetails, long id);
        Task Delete(long id);
        Task<List<Order_details>> GetByTypeAsync(int pageNumber, int pageSize);
        Task<int> GetTotalCountAsync();
    }
}
