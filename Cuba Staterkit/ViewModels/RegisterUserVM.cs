using System.ComponentModel.DataAnnotations;

namespace SmartHome_Project.ViewModels
{
    public class RegisterUserVM
    {
        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        
    }
}
