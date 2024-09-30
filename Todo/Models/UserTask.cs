using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Todo.Models
{
    public class UserTask
    {
        [Key]
        public int TaskId { get; set; }
        [Required]
        public string TaskName { get; set; } = null!;
        public bool IsCompleted { get; set; } = false;
        public bool IsFavorite { get; set; } = false;

        public int UserId { get; set; }
        public User? User { get; set; } = null;


    }
}

