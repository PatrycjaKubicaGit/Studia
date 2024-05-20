using System.Collections.Generic;
using TourAgency.Models;

namespace TourAgency.Repository
{
    public interface IPlaceRepository
    {
        IEnumerable<Place> GetAllPlaces();
        Place GetPlacesById(int id);
        void InsertTrip(Place place);
        void UpdatePlace(Place place);
        void DeletePlace(int id);
        void Save();
    }
}
