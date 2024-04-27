using Biuro_Wycieczek.Models;
using Microsoft.AspNetCore.DataProtection.KeyManagement;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Biuro_Wycieczek.ViewModels;
namespace Biuro_Wycieczek.Controllers
{
	public class HomeController : Controller
	{
		private readonly ILogger<HomeController> _logger;
		private IEnumerable<TripViewModel> _wycieczka = new List<TripViewModel>
		{
			new TripViewModel
			{
				TripId = 1,
				Country = "Hiszpania, Costa del Sol",
				Destription = "Słońce, turkusowa woda, wspaniałe plaże i esencja całej Hiszpanii. Słoneczne Wybrzeże rozgrzewa rytmami flamenco i największą liczbą słonecznych dni w przeciągu roku. Wakacje w Costa del Sol to moc niezapomnianych wrażeń w malowniczej scenerii.",
				DayCount = 8,
				DepatureDate = new DateTime(2024, 6, 7, 8, 0, 0),
				Cost = 2200.0,
				DepaturePlace= "Warszawa, Lotnisko Chopina",
				FoodModel = FoodModel.AL,
				Transort = TransportModel.Samolot

			},
			new TripViewModel
			{
				TripId = 2,
				Country = "Grecja, Rodos",
                Destription = "Rodos to malownicza wyspa grecka, na której niemal zawsze świeci słońce. Ciepła woda idealna do kąpieli i kwitnące róże to wizytówka tego kurortu. To bardzo chętnie wybierane na wakacje miejsce na Morzu Egejskim z nowoczesnym centrum turystycznym.",
                DayCount = 7,
                DepatureDate = new DateTime(2024, 5, 16, 6, 0, 0),
                Cost = 6300.0,
				DepaturePlace= "Warszawa, Dworzec Centralny 01",
				FoodModel = FoodModel.FB,
				Transort = TransportModel.Autobus

			},
			new TripViewModel
			{
				TripId = 3,
				Country = "Bułgaria, Kiten",
                Destription = "Kiten to nieduży bułgarski kurort otoczony malowniczymi zatokami.Można tutaj spacerować bez końca wśród wspaniałej natury oraz leniuchować na plaży. Hotele w Kiten są nowoczesne i pełne udogodnień, a mimo to można liczyć na niższą cenę niż w innych kurortach. To niewątpliwie jedno z najpiękniejszych zakątków na wybrzeżu Morza Czarnego, z mnóstwem atrakcji. Wakacje 2024 w Kiten to okazja do tego, by się nim oczarować i dać sobie szansę na głęboki relaks pełen niespodzianek.",
                DayCount = 14,
                DepatureDate = new DateTime(2024, 8, 10, 7, 30, 0),
                Cost = 7000.0,
				DepaturePlace= "Warszawa, Dworzec Centralny 02",
				FoodModel = FoodModel.HB,
				Transort = TransportModel.Autobus

			},
			new TripViewModel
			{
				TripId = 4,
				Country = "Turcja, Bodrum",
                Destription = "Bodrum to taki kurort, w którym każdy znajdzie coś dla siebie. Nie bez powodu jest najpopularniejszym ośrodkiem turystycznym w całej Turcji. Położone na półwyspie malownicze miasto oferuje mnóstwo różnych atrakcji. Słynie przede wszystkim z piaszczystych i żwirowych plaż, małych urokliwych zatoczek, ciekawej roślinności, pięknych widoków, ale też bogatego życia nocnego.",
                DayCount = 7,
                DepatureDate = new DateTime(2024, 5, 14, 12, 0, 0),
                Cost = 5550.0,
				DepaturePlace= "Warszawa, Lotnisko Chopina",
				FoodModel = FoodModel.AL,
				Transort = TransportModel.Samolot

			},
			new TripViewModel
			{
				TripId = 5,
				Country = "Polska, Gdynia",
                Destription = "Gdynia leży na wybrzeżu Zatoki Gdańskiej i wchodzi w skład Trójmiasta , razem z Gdańskiem i Sopotem. Jest to młode miasto, które powstało razem z portem, w zasadzie w szczerym polu, w okresie międzywojennym i otworzyło Polsce dostęp do morza",
                DayCount = 14,
                DepatureDate = new DateTime(2024, 7, 20, 8, 0, 0),
                Cost = 3000.0,
				DepaturePlace= "Warszawa, Dworzec Centralny",
				FoodModel = FoodModel.Brak,
				Transort = TransportModel.Pociąg

			},



		};

		public HomeController(ILogger<HomeController> logger)
		{
			_logger = logger;
		}

		public IActionResult Index()
		{
			return View(_wycieczka);
		}

		public IActionResult Privacy()
		{
			return View();
		}
		public IActionResult WycieczkaDetail(int id)
		{
			var wycieczka = _wycieczka.FirstOrDefault(wycieczka => wycieczka.TripId == id);
			return View(wycieczka);

		}

		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}
	}
}