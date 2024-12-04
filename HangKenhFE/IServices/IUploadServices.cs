namespace HangKenhFE.IServices
{
    public interface IUploadServices
    {
        //Task<UploadResponse> UploadExcel(string tableName, IFormFile file);
        Task<byte[]> ExportExcel(string tableName);
    }
}
