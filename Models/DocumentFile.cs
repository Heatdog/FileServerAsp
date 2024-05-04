
using System.ComponentModel.DataAnnotations;

namespace fileServer.Models{
    public class DocumentFile{
        public DocumentFile(Guid id, string path){
            Id = id;
            Path = path;
        }
        [Key]
        public Guid Id { get; set; }
        public string Path { get; set; }
    }
}