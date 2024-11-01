using ITHelpDeskClient.Models;
using ITHelpDeskClient.Models.ViewModels;

namespace ViewModels
{
    public class CreateTicketVM
    {
        public AppUser? User { get; set; }
        public RequestVM Request { get; set; } = new RequestVM();
    }
}
