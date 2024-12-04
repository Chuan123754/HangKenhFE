using HangKenhFE.Models;
using HangKenhFE.Models.DTO;

namespace HangKenhFE.IServices
{
    public interface IOrderTrackingServices
    {
        Task<OrderTrackingDTO> GetBy(long Id);
        Task<List<Orders>> GetAllOrders();
        Task<string> AddOrderTracking(order_trackings newOrderTracking);
        Task<string> UpdateOrderTracking(long id, order_trackings updatedOrderTracking);
        Task<string> DeleteOrderTracking(long id);
    }
}
