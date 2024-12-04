﻿    using HangKenhFE.Models;

namespace HangKenhFE.IServices
{
    public interface ICategoriesServices
    {
        Task<List<Categories>> GetAll();
        Task<List<Categories>> GetAllType(string type);
        Task<List<Post_categories>> GetCategoryByPosstId(long postId);
        Task<Categories> Details(long id);
        Task Create(Categories c);
        Task CreateTypePost(Categories c);
        Task CreateTypeProject(Categories c);
        Task CreateTypeProduct(Categories c);
        Task Update(Categories c);
        Task Delete(long id);
        Task<List<Categories>> GetByTypeAsync(string type, int pageNumber, int pageSize, string searchTerm);
        Task<int> GetTotalCountAsync(string type, string searchTerm);
    }
}
