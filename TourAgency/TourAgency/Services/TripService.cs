using TourAgency.Models;
using TourAgency.Repository;

public class TripService : ITripService
{
    private readonly ITripRepository _tripRepository;

    public TripService(ITripRepository tripRepository)
    {
        _tripRepository = tripRepository;
    }
    public int GetTotalNumberOfTrips()
    {
        var trips = _tripRepository.GetAllTrips();
        return trips.Count();
    }

    public IEnumerable<Trips> GetTripsPerPage(int page, int pageSize)
    {
        var allTrips = _tripRepository.GetAllTrips();
        return allTrips.Skip((page - 1) * pageSize).Take(pageSize);
    }


    public IEnumerable<Trips> GetAllTrips()
    {
        return _tripRepository.GetAllTrips();
    }

    public void InsertTrip(Trips model)
    {
        _tripRepository.InsertTrip(model);
    }

    public void Save()
    {
        _tripRepository.Save();
    }

    public Trips GetTripById(int Id)
    {
        return _tripRepository.GetTripById(Id);
    }

    public void UpdateTrip(Trips model)
    {
        _tripRepository.UpdateTrip(model);
    }

    public void DeleteTrip(int Id)
    {
        _tripRepository.DeleteTrip(Id);
    }
}
