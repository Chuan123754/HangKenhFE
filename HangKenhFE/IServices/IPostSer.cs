using HangKenhFE.Models;

namespace HangKenhFE.IServices
{
    public interface IPostSer
    {
        Task<List<Product_Posts>> GetAllType(string type);
        Task<Product_Posts> GetByIdType(long id, string type);
        Task<List<Product_Posts>> GetCountByType(string type, long designerId);

        Task<List<Product_Posts>> GetByTypeAsync(string type, int pageNumber, int pageSize, string searchTerm);
        Task<int> GetTotalCountAsync(string type, string searchTerm);
        //Phân trang theo type và id cate
        Task<List<Product_Posts>> GetByTypeAsyncCate(string type, long categoryId, int pageNumber, int pageSize);

        // Lấy tổng số bài viết theo type và id cate
        Task<string?> GetNameDesigner(long id);
        Task<int> GetTotalCountAsyncCate(string type, long categoryId);
        // Tạo bài viết
        Task CreatePost(Product_Posts post, List<long> tagIds, List<long> category);
        Task CreatePage(Product_Posts post, List<long> tagIds);
        Task CreateProduct(Product_Posts post, List<long> tagIds, List<long> category);
        Task CreateProject(Product_Posts post, List<long> tagIds, List<long> category);
        Task Delete(long id);
        Task Update(Product_Posts post);
    }
}
