using System.ComponentModel.DataAnnotations;

namespace FrontToBack.DTO.UserDTO
{
    public class LoginUserDto
    {
        [Required]
        [Display(Prompt = "Email or Username")]
        public string EmailOrUserName { get; set; }

        [Required]
        [Display(Prompt = "Password")]
        public string Password { get; set; }
    }
}
