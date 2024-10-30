using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace ITHelpDeskClient.Models
{
    public class AppUser : IdentityUser
    {
        [Required]
        public string? Name { get; set; }
        public string? LastName { get; set; }
        public Genero Genero { get; set; }
    }

    public enum Genero
    {
        Male,
        Female,
        Other
    }
}
