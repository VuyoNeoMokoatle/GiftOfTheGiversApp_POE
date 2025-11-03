namespace GiftOfTheGiversApp.Models
{
    public class Incident
    {
        public int IncidentID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Location { get; set; }
        public string Severity { get; set; }
        public DateTime ReportedAt { get; set; } = DateTime.UtcNow;
    }

}
