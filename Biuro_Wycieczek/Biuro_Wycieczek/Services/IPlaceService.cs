using Biuro_Wycieczek.Models;
using System.Collections.Generic;

public interface IPlaceService
{
    IEnumerable<Place> GetAllPlaces();
    IEnumerable<Place> GetPlacesPerPage(int page, int pageSize);
    Place GetPlaceById(int PlaceId);
    int GetTotalNumberOfPlaces();
    void InsertPlace(Place place);
    void UpdatePlace(Place place);
    void DeletePlace(int PlaceId);
    void Save();
}
