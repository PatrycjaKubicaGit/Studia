using Biuro_Wycieczek.Models;
using System.Collections.Generic;

namespace Biuro_Wycieczek.ViewModelPages
{
    public class PlaceViewModelPages
    {
        public IEnumerable<Place> Places { get; set; }
        public int TotalPlaces { get; set; }
        public int PageSize { get; set; }
        public int CurrentPage { get; set; }
    }
}

