using System.ComponentModel.DataAnnotations;

namespace wandaTechIntern.Models
{
    public class RegisterUserVm
    {
        [MaxLength(10, ErrorMessage = "Max length is 10")]
        [Required]
        public string Name { get; set; }

        [MinLength(2, ErrorMessage = "The minimun shoud be atleast 2 characters")]
        public string Phone { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        public string Email { get; set; }
    }
}