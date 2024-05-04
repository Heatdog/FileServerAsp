using fileServer.Models;
using fileServer.Services.Databases;
using fileServer.Services.RepositoryService.Interfaces;

namespace fileServer.Services.RepositoryService.Repository{
    public class FileRepository : IFileRepository{
        private ApplicationContext db;
        public FileRepository(ApplicationContext db){
            this.db = db;
        }

        public Errors InsertDocument(DocumentFile documentFile){
            db.Files.Add(documentFile);
            try{
                db.SaveChanges();
            }catch (Exception){
                return Errors.SaveDbError;
            }
            return Errors.None;
        }

        public string? GetDocument(Guid id){
            return db.Files.FirstOrDefault(DocumentFile => DocumentFile.Id == id)?.Path;
        }
    }
}