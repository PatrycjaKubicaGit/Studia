using System.Collections.Generic;
using TourAgency.Models;

namespace TourAgency.Repository
{
    public interface IGuideRepository
    {
        IEnumerable<Guide> GetAllGuides();
        Guide GetGuideById(int id);
        void InsertGuide(Guide guide);
        void UpdateGuide(Guide guide);
        void DeleteGuide(int id);
        void Save();
    }
}
