using HangKenhFE.Models;

namespace HangKenhFE.IServices
{
    public interface IDesignerServices
    {
        Task<List<Designer>> GetAll();
        Task<Designer> GetById(long id);

        Task<List<Designer>> GetByTypeAsync(int pageNumber, int pageSize, string searchTerm);
        Task<int> GetTotalCountAsync(string searchTerm);
    }
}
