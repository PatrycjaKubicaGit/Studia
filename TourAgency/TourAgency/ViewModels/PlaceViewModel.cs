using AutoMapper;
using FluentValidation;
using TourAgency.Models;

namespace TourAgency.ViewModels
{
    public class PlaceViewModel
    {
        public int PlaceId { get; set; }
        public string Name { get; set; }
        public TypModel Type { get; set; }
        public int DistanceFromSea { get; set; }
        public bool Pool { get; set; }
        public bool Carpark { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public int LocalNumber { get; set; }
    }

    public class PlaceProfile : Profile
    {
        public PlaceProfile()
        {
            CreateMap<Place, PlaceViewModel>();
            CreateMap<PlaceViewModel, Place>();
        }
    }

    public class PlaceViewModelValidator : AbstractValidator<PlaceViewModel>
    {
        public PlaceViewModelValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Nazwa jest wymagana.");
            RuleFor(x => x.City).NotEmpty().WithMessage("Miasto jest wymagane.");
            RuleFor(x => x.Street).NotEmpty().WithMessage("Ulica jest wymagana.");
            RuleFor(x => x.LocalNumber).NotEmpty().WithMessage("Nrlokalu jest wymagane.");
        }
    }
}
