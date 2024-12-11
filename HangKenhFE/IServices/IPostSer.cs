﻿using HangKenhFE.Models;

namespace HangKenhFE.IServices
{
    public interface IPostSer
    {
        Task<List<Product_Attributes>> GetProductAttributesByProductVarianIdClient(long id);
        Task<List<Product_Posts>> GetAllType(string type);
        Task<Product_Posts> GetByIdType(long id, string type);
        Task<List<Product_Posts>> GetCountByType(string type, long designerId);
        Task<List<Product_variants>> GetCountByTypeDesigner(long designerId);
        Task<List<Product_variants>> GetAllByClient();
        Task<List<Product_Posts>> GetAllByClientTypeCate(string type, string cate);
        Task<List<Product_Posts>> GetByTypeAsync(string type, int pageNumber, int pageSize, string searchTerm);
        Task<int> GetTotalCountAsync(string type, string searchTerm);
        //Phân trang theo type và id cate
        Task<List<Product_Posts>> GetByTypeAsyncCate(string type, long categoryId, int pageNumber, int pageSize);
        Task<List<Product_variants>> GetByTypeAsyncProduct(string type, int pageNumber, int pageSize, string searchTerm);
        // Lấy tổng số bài viết theo type và tìm kiếm
        Task<int> GetTotalCountAsyncProduct(string type, string searchTerm);
        // Lấy tổng số bài viết theo type và id cate
        Task<string> GetNameDesigner(long id);
        Task<int> GetTotalCountAsyncCate(string type, long categoryId);
        
        Task<List<Product_variants>> GetByTypeAsyncProductColor(long idColor, int pageNumber, int pageSize);
        // Lấy tổng số bài viết theo type và tìm kiếm
        Task<int> GetTotalCountAsyncProductColor(long idColor);
        Task<List<Product_variants>> GetByTypeAsyncProductSize(long idSize, int pageNumber, int pageSize);
        Task<int> GetTotalCountAsyncProductSize(long idSize);
        Task<List<Product_variants>> GetByTypeAsyncProductStyle(long idStyle, int pageNumber, int pageSize);
        Task<int> GetTotalCountAsyncProductStyle(long idStyle);
        Task<List<Product_variants>> GetByTypeAsyncProductMaterial(long idMaterial, int pageNumber, int pageSize);
        Task<int> GetTotalCountAsyncProductMaterial(long idMaterial);
        Task<List<Product_variants>> GetByTypeAsyncProductTextile_technology(long idTextile_technology, int pageNumber, int pageSize);
        Task<int> GetTotalCountAsyncProductTextile_technology(long idTextile_technology);
        Task<List<Product_variants>> GetByTypeAsyncProductDesigner(long idDesigner, int pageNumber, int pageSize);
        Task<int> GetTotalCountAsyncProductDesigner(long idDesigner);
        Task<List<Product_variants>> GetByTypeAsyncFilter(List<long?> idDesigner, List<long?> idColor, List<long?> idMaterial, List<long?> idTextile_technology, List<long?> idStyle, List<long?> idSize, List<long?> idCategory, int pageNumber, int pageSize, string searchTerm);
        Task<int> GetTotalCountAsyncFilter(List<long?> idDesigner, List<long?> idColor, List<long?> idMaterial, List<long?> idTextile_technology, List<long?> idStyle, List<long?> idSize, List<long?> idCategory, string searchTerm);

        Task<List<Product_Posts>> GetByTypeAsyncFilter2(string type, List<long?> idDesigner, List<long?> idCategory, int pageNumber, int pageSize, string searchTerm);
        Task<int> GetTotalCountAsyncFilter2(string type, List<long?> idDesigner, List<long?> idCategory, string searchTerm);
    }
}
