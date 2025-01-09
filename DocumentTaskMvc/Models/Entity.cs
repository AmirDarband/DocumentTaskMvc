using System.ComponentModel.DataAnnotations;

namespace DocumentTaskMvc.Models
{
    public class Entity
    {
        [Key]
        public int EntityId { get; set; }
        public string Name { get; set; }

        public ICollection<Document> Documents { get; set; }
       
    }
}
