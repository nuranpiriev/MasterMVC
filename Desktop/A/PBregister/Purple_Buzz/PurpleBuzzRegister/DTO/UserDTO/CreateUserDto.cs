using System.ComponentModel.DataAnnotations;

namespace FrontToBack.DTO.UserDTO
{
    public class CreateUserDto
    {
        [Required]
        [Display(Prompt ="Firstname")]
        public string FirstName { get; set; }

        [Required]
        [Display(Prompt = "Lastname")]
        public string LastName { get; set; }
        
        [Required]
        [Display(Prompt = "Email")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Display(Prompt = "Password")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        
        [Display(Prompt = "Repeat Password")]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }
    }
}
