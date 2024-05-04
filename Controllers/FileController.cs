using fileServer.Models;
using fileServer.Services.FileService;
using fileServer.Services.RepositoryService.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace fileServer.Controllers{
    public class FileController : Controller{
        private readonly IWebHostEnvironment _env;
        private readonly IFileService _fileService;
        private readonly IFileRepository _fileRepository;
        public FileController(IWebHostEnvironment env, IFileService fileService, IFileRepository fileRepository){
            _env = env;
            _fileService = fileService;
            _fileRepository = fileRepository;
        }
        [HttpPost, Route("insert")]
        public async Task<IResult> Insert(IFormFile file){
            var fileID = Guid.NewGuid();
            var path = Path.GetFullPath(Path.Combine(_env.WebRootPath, $"Files/{fileID}"));
            var res = await _fileService.UploadFile(path, file);
            if (!res){
                return Results.BadRequest();
            }
            var err = _fileRepository.InsertDocument(new DocumentFile(fileID, path));
            if (err != Errors.None){
                return Results.Json(new ErrorMessage(err), statusCode: 500);
            }
            return Results.Ok(fileID);
        }
        [HttpGet, Route("get/{id:guid}")]
        public IResult Get(Guid ID){
            var path = _fileRepository.GetDocument(ID);
            if (path == null){
                return Results.Json(new ErrorMessage(Errors.EmptyValue), statusCode: 500);
            }

            var fileBytes = System.IO.File.ReadAllBytes(path);
            return Results.File(fileBytes, "application/pdf");
        } 
    }
}