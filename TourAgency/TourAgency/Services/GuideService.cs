// PrzewodnikService.cs
using TourAgency.Models;
using TourAgency.Repository;
using System.Collections.Generic;

public class GuideService : IGuideService
{
    private readonly IGuideRepository _guideRepository;

    public GuideService(IGuideRepository guideRepository)
    {
        _guideRepository = guideRepository;
    }
    public int GetTotalNumberOfGuides()
    {
        var guides = _guideRepository.GetAllGuides();
        return guides.Count();
    }

    public IEnumerable<Guide> GetGuidesPerPage(int page, int pageSize)
    {
        var allGuides = _guideRepository.GetAllGuides();
        return allGuides.Skip((page - 1) * pageSize).Take(pageSize);
    }


    public IEnumerable<Guide> GetAllGuides()
    {
        return _guideRepository.GetAllGuides();
    }

    public Guide GetGuideById(int PrzewodnikId)
    {
        return _guideRepository.GetGuideById(PrzewodnikId);
    }

    public void InsertGuide(Guide przewodnik)
    {
        _guideRepository.InsertGuide(przewodnik);
    }

    public void UpdateGuide(Guide przewodnik)
    {
        _guideRepository.UpdateGuide(przewodnik);
    }

    public void DeleteGuide(int PrzewodnikId)
    {
        _guideRepository.DeleteGuide(PrzewodnikId);
    }

    public void Save()
    {
        _guideRepository.Save();
    }
}
