using AutoMapper;
using FluentValidation;
using TourAgency.Models;

namespace TourAgency.ViewModels
{
    public class TripViewModel
    {
        public int TripsId { get; set; }
        public string Country { get; set; }
        public string Description { get; set; }
        public int DayCount { get; set; }
        public DateTime DepatureDate { get; set; }
        public double Cost { get; set; }
        public string DepaturePlace { get; set; }
        public FoodModel FoodModel { get; set; }
        public TransportModel Transort { get; set; }
        public Place? PlacesId { get; set; }

        public PlaceViewModel Place { get; set; }
    }



    public class TripProfile : Profile
    {
        public TripProfile()
        {
            CreateMap<Trips, TripViewModel>();
            CreateMap<TripViewModel, Trips>();
        }
    }

    public class TripViewModelValidator : AbstractValidator<TripViewModel>
    {
        public TripViewModelValidator()
        {
            RuleFor(x => x.Country).NotEmpty().WithMessage("Miejsce jest wymagane.");
            RuleFor(x => x.Description).NotEmpty().WithMessage("Opis jest wymagany.");
            RuleFor(x => x.DayCount).NotEmpty().WithMessage("IleDni jest wymagane.");
            RuleFor(x => x.DepatureDate).NotEmpty().WithMessage("DataOdjazdu jest wymagana.");
            RuleFor(x => x.Cost).NotEmpty().WithMessage("Koszt jest wymagany.");
            RuleFor(x => x.DepaturePlace).NotEmpty().WithMessage("MiejsceOdjazdu jest wymagane.");
        }
    }
}
