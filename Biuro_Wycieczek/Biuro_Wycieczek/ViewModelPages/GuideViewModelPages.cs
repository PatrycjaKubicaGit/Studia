
using Biuro_Wycieczek.Models;
using System.Collections.Generic;

namespace Biuro_Wycieczek.ViewModelPages
{
    public class GuideViewModelPages
    {
        public IEnumerable<Guide> Guides { get; set; }
        public int TotalGuides { get; set; }
        public int PageSize { get; set; }
        public int CurrentPage { get; set; }
    }
}
