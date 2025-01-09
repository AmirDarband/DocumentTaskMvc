using System.ComponentModel.DataAnnotations;

namespace DocumentTaskMvc.Models
{
    public class Document
    {
        [Key]
        public int DocumentsId { get; set; }
        public int EntityId { get; set; }
        public int UserId { get; set; }
        public string Title { get; set; }
        public string FilePath { get; set; }
        public DateTime CreatedDate { get; set; }

        #region Relations
        public Entity Entity { get; set; }
        public User User { get; set; }
        #endregion
    }
}
