using AutoMapper;
using FluentValidation;
using Biuro_Wycieczek.Models;

namespace Biuro_Wycieczek.ViewModels
{
    public class ClientViewModel
    {
        public int ClientId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Contact { get; set; }
    }

    public class ClientFormProfile : Profile
    {
        public ClientFormProfile()
        {
            CreateMap<Client, ClientViewModel>();
            CreateMap<ClientViewModel, Client>();
        }
    }

    public class ClientViewModelValidator : AbstractValidator<ClientViewModel>
    {
        public ClientViewModelValidator()
        {
            RuleFor(x => x.FirstName).NotEmpty().WithMessage("Imię jest wymagane.");
            RuleFor(x => x.LastName).NotEmpty().WithMessage("Nazwisko jest wymagane.");
            RuleFor(x => x.Contact).NotEmpty().WithMessage("Kontakt jest wymagany.");
        }
    }
}
