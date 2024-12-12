using HangKenhFE.Models;

namespace HangKenhFE.IServices
{
    public interface IWishlistServices
    {
        Task<List<Wishlist>> GetAll();
        Task<Wishlist> GetById(long id);
        Task Create(Wishlist wl);
        Task Update(Wishlist wl);
        Task Delete(long id);
    }
}
