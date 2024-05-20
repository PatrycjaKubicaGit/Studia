
using TourAgency.Models;
using System.Collections.Generic;

public interface IGuideService
{
    IEnumerable<Guide> GetAllGuides();
    IEnumerable<Guide> GetGuidesPerPage(int page, int pageSize);
    int GetTotalNumberOfGuides();
    Guide GetGuideById(int id);
    void InsertGuide(Guide guide);
    void UpdateGuide(Guide guide);
    void DeleteGuide(int id);
    void Save();
}
