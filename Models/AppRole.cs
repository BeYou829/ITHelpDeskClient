using Microsoft.AspNetCore.Identity;

namespace ITHelpDeskClient.Models
{
    public class AppRole : IdentityRole
    {
        public string? Description { get; set; }
    }
}
