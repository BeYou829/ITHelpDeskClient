using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ITHelpDeskClient.Models.ViewModels
{
    public class EditUserVM
    {
        [Display(Name = "Nombre")]
        public string? Name { get; set; }
        [Display(Name = "Apellido")]
        public string? LastName { get; set; }
        [Display(Name = "Usuario")]
        public string? UserName { get; set; }
        [Display(Name = "Correo Electrónico")]
        [DataType(DataType.EmailAddress)]
        public string? Email { get; set; }
        [Display(Name = "Número de Teléfono")]
        [DataType(DataType.PhoneNumber)]
        public string? PhoneNumber { get; set; }
        [Display(Name = "Género")]
        public Genero Genero { get; set; }
        [Display(Name = "Contraseña Actual")]
        [DataType(DataType.Password)]
        public string? CurrentPassword { get; set; }
        [Display(Name = "Nueva Contraseña")]
        [DataType(DataType.Password)]
        public string? NewPassword { get; set; }
        [Display(Name = "Confirmar Contraseña")]
        [DataType(DataType.Password)]
        [Compare("NewPassword", ErrorMessage = "La contraseña no es igual")]
        public string? ConfirmPassword { get; set; }
    }
}
