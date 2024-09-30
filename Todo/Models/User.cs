using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Todo.Models
{
    public class User
    {
        [Key]
        public int UserId { get; set; }

        [Required]
        public string Username { get; set; }

        [Required(ErrorMessage = "email is required")]
        [EmailAddress(ErrorMessage = "Invalid email format")]

        public string Email { get; set; }
        public string Password { get; set; }

        //public virtual ICollection<UserTask> Tasks { get; set; } = new List<UserTask>();
    }
}
