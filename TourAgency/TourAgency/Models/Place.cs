using System.ComponentModel.DataAnnotations;

namespace TourAgency.Models
{
    public enum TypModel
    {
        Hotel, Motel, Hostel, PoleNamiotowe
    }
    public class Place
    {
        [Key]
        public int PlaceId { get; set; }
        public string Name { get; set; }
        public TypModel Type { get; set;}
        public int DistanceFromSea { get; set; }
        public bool Pool { get; set; }
        public bool Carpark { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public int LocalNumber { get; set; }

        public ICollection<Trips>? Trips { get; set; }
        

    }
}
