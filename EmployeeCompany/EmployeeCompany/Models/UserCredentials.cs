using System.ComponentModel.DataAnnotations;

namespace EmployeeCompany.Models
{
    public class UserCredentials
    {
        [Key]
        public int UserId { get; set; }

        [Required]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; } 

        [Required]
        public bool IsAdmin { get; set; } 

        public UserCredentials(int userId, string username, string password, bool isAdmin)
        {
            UserId = userId;
            Username = username;
            Password = password;
            IsAdmin = isAdmin;
        }
    }
}
