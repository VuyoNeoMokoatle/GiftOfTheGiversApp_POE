namespace GiftOfTheGiversApp.Models
{
    public class Donation
    {
        public int Id { get; set; }
        public int? ProjectId { get; set; }
        public string DonorName { get; set; }
        public decimal Amount { get; set; }
        public string DonationType { get; set; }
        public DateTime Date { get; set; }

        // Navigation property
        public ReliefProject? Project { get; set; }
    }

}
