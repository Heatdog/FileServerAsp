namespace fileServer.Services.FileService
{
    public interface IFileService
    {
        Task<bool> UploadFile(string path, IFormFile file);
    }
}