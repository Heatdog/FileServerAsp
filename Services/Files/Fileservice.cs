namespace fileServer.Services.FileService
{
    public class FileService : IFileService
    {
        public async Task<bool> UploadFile(string path, IFormFile file)
        {
            var directoryPath = Path.GetDirectoryName(path);
            Console.WriteLine($"directory path {directoryPath}");
            try
            {
                if (!Directory.Exists(directoryPath))
                {
                    Console.WriteLine("try to create directory");
                    Directory.CreateDirectory(directoryPath);
                }
                Console.WriteLine("open file stream");
                Console.WriteLine(file.FileName);

                using (var fileStream = new FileStream(path, FileMode.Create))
                {
                    await file.CopyToAsync(fileStream);
                }
                return true;
            }catch (Exception exp)
            {
                Console.WriteLine($"Failed to upload file: {exp.Message}");
                return false;
            }
        }
    }
}
