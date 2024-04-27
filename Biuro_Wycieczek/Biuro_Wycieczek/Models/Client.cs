using System.ComponentModel.DataAnnotations;

namespace Biuro_Wycieczek.Models
{
    public class Client
    {
        [Key]
        public int ClientId { get; set; }
        public string FirstName { get; set;}
        public string LastName { get; set;}
        public string Contact { get; set; }

        public ICollection<Reservation>? Reservations  { get; set; }



    }
}
