using HangKenhFE.Models;

namespace HangKenhFE.IServices
{
    public interface IOrderVoucherServices
    {
        Task<List<Order_Vouchers>> GetAll();
        Task GetByVoucherIdAndOrderId(long orderId, long voucherId);
        Task<bool> Create(Order_Vouchers order_Voucher);
    }
}
