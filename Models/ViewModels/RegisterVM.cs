using System.ComponentModel.DataAnnotations;

namespace ITHelpDeskClient.Models.ViewModels
{
    public class RegisterVM
    {
        [Required]
        [Display(Name = "First Name")]
        public string? FirstName { get; set; }
        [Required]
        [Display(Name = "Last Name")]
        public string? LastName { get; set; }
        [Required]
        [DataType(DataType.EmailAddress)]
        public string? Email { get; set; }
        [Required]
        
        public string? UserName { get; set; }
        [Required]
        [Display(Name = "Genre")]
        public Genero Genre { get; set; }
        [Required]
        [Display(Name = "Phone Number")]
        [Length(9,10)]
        [DataType(DataType.PhoneNumber)]
        public string? PhoneNumber { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string? Password { get; set; }
        [Compare("Password", ErrorMessage = "La contraseña no es igual")]
        [Display(Name = "Confirm Password")]
        public string? ConfirmPassword { get; set; }

    }
}
