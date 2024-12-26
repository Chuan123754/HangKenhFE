using HangKenhFE.Models;

namespace HangKenhFE.IServices
{
    public interface IProduct_wishlist_Services
    {
        Task<List<Product_wishlist>> GetAllPW();
        Task<Product_wishlist> GetByID(long id);
        Task Create(Product_wishlist pw);
        Task Delete(long id);
    }
}
