using Biuro_Wycieczek.Models;

public interface ITripService
{
    IEnumerable<Trips> GetAllTrips();
    IEnumerable<Trips> GetTripsPerPage(int page, int pageSize);
    int GetTotalNumberOfTrips();
    void InsertTrip(Trips model);
    void Save();
    Trips GetTripById(int Id);
    void UpdateTrip(Trips model);
    void DeleteTrip(int Id);
}
