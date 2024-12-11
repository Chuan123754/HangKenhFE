using HangKenhFE.IServices;
using HangKenhFE.Models;
using HangKenhFE.Pages.Client;
using Newtonsoft.Json;
using System.ComponentModel;
using System.Drawing;

namespace HangKenhFE.Services
{
    public class PostServices : IPostSer
    {
        private readonly HttpClient _client;
        private readonly string _baseUrl;
        public PostServices(IConfiguration configuration)
        {
            _client = new HttpClient();
            _baseUrl = configuration.GetValue<string>("ApiSettings:BaseUrl"); // Lấy URL từ appsettings.json
        }
        public async Task<List<Product_Attributes>> GetProductAttributesByProductVarianIdClient(long id)
        {
            string requestURL = $"{_baseUrl}/api/ProductAttributes/GetProductAttributesByProductVarianIdClient?id={id}";
            var response = await _client.GetStringAsync(requestURL);
            return JsonConvert.DeserializeObject<List<Product_Attributes>>(response);
        }
       
        public async Task<List<Product_Posts>> GetAllType(string type)
        {
            return await _client.GetFromJsonAsync<List<Product_Posts>>($"{_baseUrl}/api/Product_Post/Get-all-type?Type={type}");
        }

        public async Task<Product_Posts> GetByIdType(long id, string type)
        {
            return await _client.GetFromJsonAsync<Product_Posts>($"{_baseUrl}/api/Product_Post/GetByIdAndType?id={id}&type={type}");
        }

        public async Task<List<Product_Posts>> GetByTypeAsync(string type, int pageNumber, int pageSize, string searchTerm)
        {

            var uri = $"{_baseUrl}/api/Product_Post/get-by-type?type={type}&pageNumber={pageNumber}&pageSize={pageSize}&searchTerm={Uri.EscapeDataString(searchTerm)}";
            return await _client.GetFromJsonAsync<List<Product_Posts>>(uri);
        }

        public async Task<List<Product_Posts>> GetByTypeAsyncCate(string type, long categoryId, int pageNumber, int pageSize)
        {
            var uri = $"{_baseUrl}/api/Product_Post/get-by-type-cate?type={type}&categoryId={categoryId}&pageNumber={pageNumber}&pageSize={pageSize}";
            return await _client.GetFromJsonAsync<List<Product_Posts>>(uri);
        }

        public async Task<int> GetTotalCountAsyncCate(string type, long categoryId)
        {
            var url = $"{_baseUrl}/api/Product_Post/Get-Total-Count-Cate?type={type}&categoryId={categoryId}";

            // Gọi API và nhận tổng số lượng bài viết
            var response = await _client.GetAsync(url);
            response.EnsureSuccessStatusCode(); // Kiểm tra xem phản hồi có thành công hay không

            var count = await response.Content.ReadFromJsonAsync<int>();
            return count;
        }
        public async Task<List<Product_Posts>> GetCountByType(string type, long designerId)
        {
            return await _client.GetFromJsonAsync<List<Product_Posts>>($"{_baseUrl}/api/Product_Post/GetCountByType?type={type}&designerId={designerId}");
        }

        public async Task<int> GetTotalCountAsync(string type, string searchTerm)
        {
            var url = $"{_baseUrl}/api/Product_Post/Get-Total-Count?type={type}&searchTerm={Uri.EscapeDataString(searchTerm)}";

            // Gọi API và nhận tổng số lượng bài viết
            var response = await _client.GetAsync(url);
            response.EnsureSuccessStatusCode(); // Kiểm tra xem phản hồi có thành công hay không

            var count = await response.Content.ReadFromJsonAsync<int>();
            return count;
        }

   

        public async Task<string?> GetNameDesigner(long id)
        {
            // Gửi yêu cầu GET đến API
            var response = await _client.GetStringAsync($"{_baseUrl}/api/Product_Post/Get-Name-Designer?id={id}");
            return response; // Kết quả trả về sẽ là chuỗi JSON hoặc chuỗi đơn giản
        }

        public async Task<List<Product_variants>> GetAllByClient()
        {
            var uri = $"{_baseUrl}/api/Product_Post/GetAllByClient";
            // Lấy dữ liệu từ API và ánh xạ vào danh sách Product_variants
            return await _client.GetFromJsonAsync<List<Product_variants>>(uri);
        }

        public async Task<List<Product_variants>> GetByTypeAsyncProduct(string type, int pageNumber, int pageSize, string searchTerm)
        {
            var uri = $"{_baseUrl}/api/Product_Post/get-by-type-product?type={type}&pageNumber={pageNumber}&pageSize={pageSize}&searchTerm={Uri.EscapeDataString(searchTerm)}";
            return await _client.GetFromJsonAsync<List<Product_variants>>(uri);
        }

        public async Task<int> GetTotalCountAsyncProduct(string type, string searchTerm)
        {
            var url = $"{_baseUrl}/api/Product_Post/Get-Total-Count-Product?type={type}&searchTerm={Uri.EscapeDataString(searchTerm)}";

            // Gọi API và nhận tổng số lượng bài viết
            var response = await _client.GetAsync(url);
            response.EnsureSuccessStatusCode(); // Kiểm tra xem phản hồi có thành công hay không

            var count = await response.Content.ReadFromJsonAsync<int>();
            return count;
        }

        public async Task<List<Product_Posts>> GetAllByClientTypeCate(string type, string cate)
        {
            return await _client.GetFromJsonAsync<List<Product_Posts>>($"{_baseUrl}/api/Product_Post/Get-all-client-type-cate?type={type}&cate={cate}");
        }

        public async Task<List<Product_variants>> GetCountByTypeDesigner(long designerId)
        {
            return await _client.GetFromJsonAsync<List<Product_variants>>($"{_baseUrl}/api/Product_Post/GetCountByTypeDesigner?designerId={designerId}");
        }

        public async Task<List<Product_variants>> GetByTypeAsyncProductColor(long idColor, int pageNumber, int pageSize)
        {
            var uri = $"{_baseUrl}/api/Product_Post/get-by-product-color?idColor={idColor}&pageNumber={pageNumber}&pageSize={pageSize}";
            return await _client.GetFromJsonAsync<List<Product_variants>>(uri);
        }

        public async Task<int> GetTotalCountAsyncProductColor(long idColor)
        {
            var url = $"{_baseUrl}/api/Product_Post/Get-Total-Count-Product-Color?idColor={idColor}";

            // Gọi API và nhận tổng số lượng bài viết
            var response = await _client.GetAsync(url);
            response.EnsureSuccessStatusCode(); // Kiểm tra xem phản hồi có thành công hay không

            var count = await response.Content.ReadFromJsonAsync<int>();
            return count;
        }


        public async Task<List<Product_variants>> GetByTypeAsyncProductSize(long idSize, int pageNumber, int pageSize)
        {
            var uri = $"{_baseUrl}/api/Product_Post/get-by-product-size?idSize={idSize}&pageNumber={pageNumber}&pageSize={pageSize}";
            return await _client.GetFromJsonAsync<List<Product_variants>>(uri);
        }

        public async Task<int> GetTotalCountAsyncProductSize(long idSize)
        {
            var url = $"{_baseUrl}/api/Product_Post/Get-Total-Count-Product-Size?idSize={idSize}";

            // Gọi API và nhận tổng số lượng bài viết
            var response = await _client.GetAsync(url);
            response.EnsureSuccessStatusCode(); // Kiểm tra xem phản hồi có thành công hay không

            var count = await response.Content.ReadFromJsonAsync<int>();
            return count;
        }

        public async Task<List<Product_variants>> GetByTypeAsyncProductStyle(long idStyle, int pageNumber, int pageSize)
        {
            var uri = $"{_baseUrl}/api/Product_Post/get-by-product-style?idStyle={idStyle}&pageNumber={pageNumber}&pageSize={pageSize}";
            return await _client.GetFromJsonAsync<List<Product_variants>>(uri);
        }

        public async Task<int> GetTotalCountAsyncProductStyle(long idStyle)
        {
            var url = $"{_baseUrl}/api/Product_Post/Get-Total-Count-Product-Style?idStyle={idStyle}";

            // Gọi API và nhận tổng số lượng bài viết
            var response = await _client.GetAsync(url);
            response.EnsureSuccessStatusCode(); // Kiểm tra xem phản hồi có thành công hay không

            var count = await response.Content.ReadFromJsonAsync<int>();
            return count;
        }

        public async Task<List<Product_variants>> GetByTypeAsyncProductMaterial(long idMaterial, int pageNumber, int pageSize)
        {
            var uri = $"{_baseUrl}/api/Product_Post//get-by-product-material?idMaterial={idMaterial}&pageNumber={pageNumber}&pageSize={pageSize}";
            return await _client.GetFromJsonAsync<List<Product_variants>>(uri);
        }

        public async Task<int> GetTotalCountAsyncProductMaterial(long idMaterial)
        {
            var url = $"{_baseUrl}/api/Product_Post/Get-Total-Count-Product-Material?idMaterial={idMaterial}";

            // Gọi API và nhận tổng số lượng bài viết
            var response = await _client.GetAsync(url);
            response.EnsureSuccessStatusCode(); // Kiểm tra xem phản hồi có thành công hay không

            var count = await response.Content.ReadFromJsonAsync<int>();
            return count;
        }

        public async Task<List<Product_variants>> GetByTypeAsyncProductTextile_technology(long idTextile_technology, int pageNumber, int pageSize)
        {
            var uri = $"{_baseUrl}/api/Product_Post/get-by-product-textile_technology?idTextile_technology={idTextile_technology}&pageNumber={pageNumber}&pageSize={pageSize}";
            return await _client.GetFromJsonAsync<List<Product_variants>>(uri);
        }

        public async Task<int> GetTotalCountAsyncProductTextile_technology(long idTextile_technology)
        {
            var url = $"{_baseUrl}/api/Product_Post/Get-Total-Count-Product-Textile_technology?idTextile_technology={idTextile_technology}";

            // Gọi API và nhận tổng số lượng bài viết
            var response = await _client.GetAsync(url);
            response.EnsureSuccessStatusCode(); // Kiểm tra xem phản hồi có thành công hay không

            var count = await response.Content.ReadFromJsonAsync<int>();
            return count;
        }

        public async Task<List<Product_variants>> GetByTypeAsyncProductDesigner(long idDesigner, int pageNumber, int pageSize)
        {
            var uri = $"{_baseUrl}/api/Product_Post/get-by-product-designer?idDesigner={idDesigner}&pageNumber={pageNumber}&pageSize={pageSize}";
            return await _client.GetFromJsonAsync<List<Product_variants>>(uri);
        }

        public async Task<int> GetTotalCountAsyncProductDesigner(long idDesigner)
        {
            var url = $"{_baseUrl}/api/Product_Post/Get-Total-Count-Product-Designer?idDesigner={idDesigner}";

            // Gọi API và nhận tổng số lượng bài viết
            var response = await _client.GetAsync(url);
            response.EnsureSuccessStatusCode(); // Kiểm tra xem phản hồi có thành công hay không

            var count = await response.Content.ReadFromJsonAsync<int>();
            return count;
        }

        public async Task<List<Product_variants>> GetByTypeAsyncFilter(List<long?> idDesigner, List<long?> idColor, List<long?> idMaterial, List<long?> idTextile_technology, List<long?> idStyle, List<long?> idSize, List<long?> idCategory, int pageNumber, int pageSize, string searchTerm)
        {
            var categoriesString = string.Join("&", idCategory.Select(c => $"idCategory={c}"));
            var colorString = string.Join("&", idColor.Select(c => $"idColor={c}"));
            var sizeString = string.Join("&", idSize.Select(c => $"idSize={c}"));
            var styleString = string.Join("&", idStyle.Select(c => $"idStyle={c}"));
            var materialString = string.Join("&", idMaterial.Select(c => $"idMaterial={c}"));
            var textileString = string.Join("&", idTextile_technology.Select(c => $"idTextile_technology={c}"));
            var designerString = string.Join("&", idDesigner.Select(c => $"idDesigner={c}"));
      
            var uri = $"{_baseUrl}/api/Product_Post/get-by-product-filter?{designerString}&{colorString}&{materialString}&{textileString}&{styleString}&{sizeString}&{categoriesString}&pageNumber={pageNumber}&pageSize={pageSize}&searchTerm={Uri.EscapeDataString(searchTerm)}";
            return await _client.GetFromJsonAsync<List<Product_variants>>(uri);
        }

        public async Task<int> GetTotalCountAsyncFilter(List<long?> idDesigner, List<long?> idColor, List<long?> idMaterial, List<long?> idTextile_technology, List<long?> idStyle, List<long?> idSize, List<long?> idCategory, string searchTerm)
        {
            var categoriesString = string.Join("&", idCategory.Select(c => $"idCategory={c}"));
            var colorString = string.Join("&", idColor.Select(c => $"idColor={c}"));
            var sizeString = string.Join("&", idSize.Select(c => $"idSize={c}"));
            var styleString = string.Join("&", idStyle.Select(c => $"idStyle={c}"));
            var materialString = string.Join("&", idMaterial.Select(c => $"idMaterial={c}"));
            var textileString = string.Join("&", idTextile_technology.Select(c => $"idTextile_technology={c}"));
            var designerString = string.Join("&", idDesigner.Select(c => $"idDesigner={c}"));
            var url = $"{_baseUrl}/api/Product_Post/Get-Total-Count-Product-Filter?{designerString}&{colorString}&{materialString}&{textileString}&{styleString}&{sizeString}&{categoriesString}&searchTerm={Uri.EscapeDataString(searchTerm)}";

            // Gọi API và nhận tổng số lượng bài viết
            var response = await _client.GetAsync(url);
            response.EnsureSuccessStatusCode(); // Kiểm tra xem phản hồi có thành công hay không

            var count = await response.Content.ReadFromJsonAsync<int>();
            return count;
        }

        public async Task<List<Product_Posts>> GetByTypeAsyncFilter2(string type, List<long?> idDesigner, List<long?> idCategory, int pageNumber, int pageSize, string searchTerm)
        {
            var categoriesString = string.Join("&", idCategory.Select(c => $"idCategory={c}"));
            var designerString = string.Join("&", idDesigner.Select(c => $"idDesigner={c}"));
            var uri = $"{_baseUrl}/api/Product_Post/get-by-product-filter2?type={type}&{designerString}&{categoriesString}&searchTerm={Uri.EscapeDataString(searchTerm)}";
            return await _client.GetFromJsonAsync<List<Product_Posts>>(uri);     
        }

        public async Task<int> GetTotalCountAsyncFilter2(string type, List<long?> idDesigner, List<long?> idCategory, string searchTerm)
        {
            var categoriesString = string.Join("&", idCategory.Select(c => $"idCategory={c}"));         
            var designerString = string.Join("&", idDesigner.Select(c => $"idDesigner={c}"));
            var url = $"{_baseUrl}/api/Product_Post/Get-Total-Count-Product-Filter2?type={type}&{designerString}&{categoriesString}&searchTerm={Uri.EscapeDataString(searchTerm)}";

            // Gọi API và nhận tổng số lượng bài viết
            var response = await _client.GetAsync(url);
            response.EnsureSuccessStatusCode(); // Kiểm tra xem phản hồi có thành công hay không

            var count = await response.Content.ReadFromJsonAsync<int>();
            return count;
        }
    }
}
