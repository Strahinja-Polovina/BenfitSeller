using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BaseLibrary.DTO
{
    public class LoginDTO
    {

        [EmailAddress(ErrorMessage = "Invalid email address")]
        [Required]
        public string Email { get; set; } = string.Empty;
        [Required]
        [PasswordPropertyText(true)]
        [MinLength(8, ErrorMessage = "Password must be at least 8 characters")]
        public string Password { get; set; } = string.Empty;
    }
}
