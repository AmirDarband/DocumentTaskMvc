using System.ComponentModel.DataAnnotations;

namespace DocumentTaskMvc.Models
{
    public class User
    {
        [Key]
        public int UserId { get; set; }
        public string Username { get; set; }
        public ICollection<Document> Documents { get; set; }
    }
}
