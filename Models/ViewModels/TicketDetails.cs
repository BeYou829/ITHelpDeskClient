namespace ITHelpDeskClient.Models.ViewModels
{
    public class TicketDetails
    {
        public AppUser? User { get; set; }
        public TicketDetailsVM TicketDetailsVM { get; set; } = new TicketDetailsVM();
    }
}
