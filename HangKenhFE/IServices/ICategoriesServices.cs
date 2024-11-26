using HangKenhFE.Models;

namespace HangKenhFE.IServices
{
    public interface ICategoriesServices
    {
        Task<List<Categories>> GetAll();
        Task<List<Categories>> GetAllType(string type);
        Task<Categories> Details(long id);
        Task<List<Categories>> GetByTypeAsync(string type, int pageNumber, int pageSize, string searchTerm);
        Task<int> GetTotalCountAsync(string type, string searchTerm);
    }
}
