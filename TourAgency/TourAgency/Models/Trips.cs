using TourAgency.ViewModels;
using System.ComponentModel.DataAnnotations;

namespace TourAgency.Models
{
    public enum FoodModel
    {
        BB, HB, FB, AL, Brak
    }
    public enum TransportModel
    {
        Autobus, Dojazd_wlasny, Samolot, Pociąg
    }
    public class Trips
    {
        [Key]
        public int TripsId { get; set; }
        public string Country { get; set; }
        public string Description { get; set; }
        public int DayCount { get; set; }
        public DateTime DepatureDate { get; set; }
        public double Cost { get; set; }
        public string DepaturePlace { get; set; }
        public FoodModel FoodModel { get; set; }
        public TransportModel Transort { get; set; }
        public Guide? Guide { get; set; }
        public Place? PlacesId { get; set; }
        public int PlacesIdPlaceId { get; set; }

        public ICollection<Reservation>? Reservations { get; set; }


    }
}

