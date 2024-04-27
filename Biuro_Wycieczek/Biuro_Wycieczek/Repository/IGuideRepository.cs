using System.Collections.Generic;
using Biuro_Wycieczek.Models;

namespace Biuro_Wycieczek.Repository
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
