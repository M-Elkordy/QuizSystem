using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace Cuba_Staterkit.Models
{
    public class ApplicationUser : IdentityUser
    {
        [Required, DataType(DataType.Password)]
        public string password { get; set; }
        public string fullName { get; set; }
    }
}
