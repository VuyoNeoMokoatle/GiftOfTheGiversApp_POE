using System.ComponentModel.DataAnnotations;

namespace GiftOfTheGiversApp.Models
{
    public class ReliefProject
    {
        [Key] // 👈 EF will now know this is the primary key
        public int ProjectId { get; set; }

        public string ProjectName { get; set; }
        public string Location { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
    }
}
