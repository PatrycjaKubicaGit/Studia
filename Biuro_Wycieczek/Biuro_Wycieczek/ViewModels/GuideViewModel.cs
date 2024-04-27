
using AutoMapper;
using FluentValidation;
using Biuro_Wycieczek.Models;

namespace Biuro_Wycieczek.ViewModels
{
    public class GuideViewModel
    {
        public int GuideId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Specialization { get; set; }
        public string Contact { get; set; }
    }

    public class PrzewodnikProfile : Profile
    {
        public PrzewodnikProfile()
        {
            CreateMap<Guide, GuideViewModel>();
            CreateMap<GuideViewModel, Guide>();
        }
    }

    public class PrzewodnikViewModelValidator : AbstractValidator<GuideViewModel>
    {
        public PrzewodnikViewModelValidator()
        {
            RuleFor(x => x.FirstName).NotEmpty().WithMessage("Imię jest wymagane.");
            RuleFor(x => x.LastName).NotEmpty().WithMessage("Nazwisko jest wymagane.");
            RuleFor(x => x.Specialization).NotEmpty().WithMessage("Specjalizacja jest wymagana.");
            RuleFor(x => x.Contact).NotEmpty().WithMessage("Kontakt jest wymagany.");
        }
    }
}
