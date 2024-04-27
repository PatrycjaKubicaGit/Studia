using AutoMapper;
using FluentValidation;
using Biuro_Wycieczek.Models;

namespace Biuro_Wycieczek.ViewModels
{
    public class ReservationViewModel
    {
        public int ReservationId { get; set; }
        public DateTime ReservationDate { get; set; }
        public int? TripsId { get; set; }
        public int? ClientsId { get; set; }
        public Trips? IdTrips { get; set; } 
        public Client? IdClients { get; set; } 
    }

    public class ReservationFormProfile : Profile
    {
        public ReservationFormProfile()
        {
            CreateMap<Reservation, ReservationViewModel>();
            CreateMap<ReservationViewModel, Reservation>();
        }
    }

    public class ReservationViewModelValidator : AbstractValidator<ReservationViewModel>
    {
        public ReservationViewModelValidator()
        {
            RuleFor(x => x.ReservationId).NotEmpty().WithMessage("IdRezerwacji jest wymagane.");
            RuleFor(x => x.ReservationDate).NotEmpty().WithMessage("DataRezerwacji jest wymagana.");
            RuleFor(x => x.TripsId).NotEmpty().WithMessage("WycieczkiId jest wymagane.");
           RuleFor(x => x.ClientsId).NotEmpty().WithMessage("KlienciId jest wymagane.");
        }
    }
}
