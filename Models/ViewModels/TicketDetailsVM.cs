namespace ITHelpDeskClient.Models.ViewModels
{
    public class TicketDetailsVM
    {
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string Status { get; set; } = string.Empty;
        public string RequestType { get; set; } = string.Empty;
        public DateTime CreatedOn { get; set; }
        public string RequestNumber { get; set; } = string.Empty;
    }
}
