using System.ComponentModel.DataAnnotations;

namespace ITHelpDeskClient.Models.ViewModels
{
    public class RequestVM
    {
        [Display(Name = "User Id")]
        public string? UserGuid { get; set; }
        [Display(Name = "Username")]
        public string? UserName { get; set; }
        [Display(Name = "Email")]
        public string? Email { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        [Display(Name = "Request Type")]
        public RequestType RequestType { get; set; }
        public virtual AppUser? AppUser { get; set; }
    }
}
