
using System.ComponentModel.DataAnnotations;

namespace fileServer.Models{
    public class DocumentFile{
        public DocumentFile(int id, string path){
            Id = id;
            Path = path;
        }
        [Key]
        public int Id { get; set; }
        public string Path { get; set; }
    }
}