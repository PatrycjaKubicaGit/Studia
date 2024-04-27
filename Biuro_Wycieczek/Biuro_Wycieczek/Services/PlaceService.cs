// MiejscePobytuService.cs
using Biuro_Wycieczek.Models;
using Biuro_Wycieczek.Repository;
using System.Collections.Generic;

public class PlaceService : IPlaceService
{
    private readonly IPlaceRepository _placeRepository;

    public PlaceService(IPlaceRepository placeRepository)
    {
        _placeRepository = placeRepository;
    }
    public int GetTotalNumberOfPlaces()
    {
        var places = _placeRepository.GetAllPlaces();
        return places.Count();
    }

    public IEnumerable<Place> GetPlacesPerPage(int page, int pageSize)
    {
        var allMiejsca = _placeRepository.GetAllPlaces();
        return allMiejsca.Skip((page - 1) * pageSize).Take(pageSize);
    }


    public IEnumerable<Place> GetAllPlaces()
    {
        return _placeRepository.GetAllPlaces();
    }

    public Place GetPlaceById(int MiejsceId)
    {
        return _placeRepository.GetPlacesById(MiejsceId);
    }

    public void InsertPlace(Place miejscePobytu)
    {
        _placeRepository.InsertTrip(miejscePobytu);
    }

    public void UpdatePlace(Place miejscePobytu)
    {
        _placeRepository.UpdatePlace(miejscePobytu);
    }

    public void DeletePlace(int MiejsceId)
    {
        _placeRepository.DeletePlace(MiejsceId);
    }

    public void Save()
    {
        _placeRepository.Save();
    }
}
