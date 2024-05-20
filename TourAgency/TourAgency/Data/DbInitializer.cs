using TourAgency.Models;
using TourAgency.Data;

namespace Biuro_Wycieczek.Data
{
    public class DbInitializer
    {
        public static void Initialize(ApplicationDbContext context)
        {
            context.Database.EnsureCreated();

            // Look for any students.
            if (context.Clients.Any())
            {
                return;   // DB has been seeded
            }

            var places = new Place[]
            {
                new Place{Name="Hotel Nadmorski", Type=TypModel.Hotel, City="Gdańsk", Street="Nadmorska", LocalNumber=10, DistanceFromSea=100, Pool=true, Carpark=true},
                new Place{Name="Hostel Śródmiejski", Type=TypModel.Hostel, City="Kraków", Street="Śródmiejska", LocalNumber=5, DistanceFromSea=0, Pool=false, Carpark=false},
            };
            foreach (Place mp in places)
            {
                context.Places.Add(mp);
            }
            context.SaveChanges();

            var guides = new Guide[]
            {
                new Guide{FirstName="Jan", LastName="Kowalski", Specialization="Historia", Contact="jan.kowalski@example.com"},
                new Guide{FirstName="Anna", LastName="Nowak", Specialization="Sztuka", Contact="anna.nowak@example.com"},
            };
            foreach (Guide p in guides)
            {
                context.Guides.Add(p);
            }
            context.SaveChanges();

            var trips = new Trips[]
            {
                new Trips{Country="Góry Stołowe", Description="Wycieczka górska w Sudetach", DayCount=5, DepatureDate=new DateTime(2024, 6, 7, 8, 0, 0), Cost=1500.00, DepaturePlace="Wrocław", FoodModel=FoodModel.HB, Transort=TransportModel.Autobus, Guide=guides[0], PlacesId=places[0]},
                new Trips{Country="Kasprowy Wierch", Description="Wycieczka w Tatrach", DayCount=3, DepatureDate=new DateTime(2024, 5, 16, 6, 0, 0), Cost=1200.00, DepaturePlace="Kraków", FoodModel=FoodModel.FB, Transort=TransportModel.Autobus, Guide=guides[1], PlacesId=places[1]},
            };
            foreach (Trips w in trips)
            {
                context.Trips.Add(w);
            }
            context.SaveChanges();

            var clients = new Client[]
            {
                new Client{FirstName="John", LastName="Doe", Contact="john.doe@example.com"},
                new Client{FirstName="Alice", LastName="Smith", Contact="alice.smith@example.com"},
            };
            foreach (Client k in clients)
            {
                context.Clients.Add(k);
            }
            context.SaveChanges();
            var reservations = new Reservation[]
            {
                new Reservation{ReservationDate=DateTime.Now,IdTrips=trips[0], IdClients=clients[0]},
                new Reservation{ReservationDate=DateTime.Now,IdTrips=trips[1], IdClients=clients[1]},
            };
            foreach (Reservation r in reservations)
            {
                context.Reservations.Add(r);
            }
            context.SaveChanges();
        }
    }
}

