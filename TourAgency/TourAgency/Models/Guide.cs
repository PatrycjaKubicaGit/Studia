using System.ComponentModel.DataAnnotations;

namespace TourAgency.Models
{
    public class Guide
    {
        [Key]
        public int GuideId { get; set; }
        public string FirstName { get;set; }
        public string LastName { get; set; }
        public string Specialization { get; set; }
        public string Contact {  get; set; }

        public ICollection<Trips>? Trips { get; set; }
    }
}
