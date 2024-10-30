using System.ComponentModel.DataAnnotations;

namespace ITHelpDeskClient.Models.ViewModels
{
    public class LoginVM
    {
        [Required(ErrorMessage = "Es requerido un nombre de usuario")]
        public string? Username { get; set; }

        [Required(ErrorMessage = "Es requerido una contraseña")]
        [DataType(DataType.Password)]
        public string? Password { get; set; }

        [Display(Name = "Remember Me")]
        public bool RememberMe { get; set; }
    }
}
