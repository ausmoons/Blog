using System.ComponentModel.DataAnnotations;

namespace BlogApp.Data.Models
{ 
    public class AuthenticateModel
    {
        [Required]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }
    }
}