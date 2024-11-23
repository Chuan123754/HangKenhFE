using HangKenhFE.Models;

namespace HangKenhFE.IServices
{
    public interface SeoIServices
    {
        Task<Seo> GetById(long id);
        Task CreateSeo(Seo seo);
        Task UpdateSeo(Seo seo);
    }
}
