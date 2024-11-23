using HangKenhFE.Models;

namespace HangKenhFE.IServices
{
    public interface ICommentServices
    {
        Task<List<Comments>> GetAll();
        Task<Comments> GetById(long id);
        Task Create(Comments comments);
        Task Update(long id, Comments comments);
        Task Delete(long id);
    }
}
