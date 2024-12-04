﻿using HangKenhFE.DTO;
using HangKenhFE.Models;

namespace HangKenhFE.IServices
{
    public interface IProductAttributeServies
    {
        Task<List<Product_Attributes>> GetAllProductAttributes();
        Task<List<Product_Attributes>> GetProductAttributesByProductVarianId(long id);
        Task<Product_Attributes> GetProductAttributesById(long id);
        Task Create(Product_Attributes productAttribute);
        Task Update(Product_Attributes productAttribute, long id);
        Task Delete(long id);
        // lấy danh sách biến thể dựa trên id sản phảm(product_variant)
        Task<List<Product_Attributes_DTO>> GetVariantByProductVariantId(List<long> variantIds);
        Task<List<Product_Attributes>> GetByTypeAsync(int pageNumber, int pageSize, string searchTerm);
        Task<int> GetTotalCountAsync(string searchTerm);
    }
}
