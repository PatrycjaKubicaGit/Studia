using System.Collections.Generic;
using Biuro_Wycieczek.Models;

namespace Biuro_Wycieczek.Repository
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
