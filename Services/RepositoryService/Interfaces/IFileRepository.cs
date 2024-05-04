
using fileServer.Models;

namespace fileServer.Services.RepositoryService.Interfaces{
    public interface IFileRepository{
        public Errors InsertDocument(DocumentFile documentFile);
        public string? GetDocument(Guid id);
    }
}