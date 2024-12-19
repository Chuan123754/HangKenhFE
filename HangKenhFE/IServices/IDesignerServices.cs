using HangKenhFE.Models;

namespace HangKenhFE.IServices
{
    public interface IDesignerServices
    {
        Task<List<Designer>> GetAll();
        Task<Designer> GetById(long id);
        Task<Designer> GetByIdSlug(string slug);
        Task<List<Designer>> GetByTypeAsyncClient(int pageNumber, int pageSize, string searchTerm);
        Task<int> GetTotalCountAsyncClient(string searchTerm);
    }
}
