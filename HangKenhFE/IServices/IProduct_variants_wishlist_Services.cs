using HangKenhFE.Models;

namespace HangKenhFE.IServices
{
    public interface IProduct_variants_wishlist_Services
    {
        Task<List<Product_variants_wishlist>> GetAllPW();
        Task<Product_variants_wishlist> GetByID(long id);
        Task Create(Product_variants_wishlist pw);
        Task Delete(long id);
    }
}
