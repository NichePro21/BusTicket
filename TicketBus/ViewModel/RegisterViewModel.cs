using System.ComponentModel.DataAnnotations;

namespace TicketBus.ViewModel
{
    public class RegisterViewModel
    {
        [Display(Name = "Email address")]
        [Required(ErrorMessage = "Email address is required")]
        public string EmailAddress { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Display(Name = "Confirm password")]
        [Required(ErrorMessage = "Confirm password is required")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Password do not match")]
        public string ConfirmPassword { get; set; }
        [Display(Name = "Full Name")]
        [Required(ErrorMessage = "Email address is required")]
        public string FullName { get; set; }
        [Display(Name = "Phone Number")]
        [Required(ErrorMessage = "Email address is required")]
        public string PhoneNumber { get; set; }
    }
}
