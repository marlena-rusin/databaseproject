using System.ComponentModel.DataAnnotations;

namespace ElectronicStore.ViewModels
{
    public class RegisterViewModel
    {
        [Display(Name = "Email address")]
        [Required(ErrorMessage = "Email address is required")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Password is required and must be at least 6 characters long, with at least one non-alphabetic character (e.g., symbol or digit) and one uppercase letter.")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Display(Name = "Confirm password")]
        [Required(ErrorMessage = "Confirm password is required")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Password do not match")]
        public string ConfirmPassword { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        [MaxLength(6)]
        public string PostalCode { get; set; }
        public int HouseNumber { get; set; }
    }
}