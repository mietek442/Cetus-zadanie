using FluentValidation;

namespace Api.Features.Desks.Commands.CreateDesk
{
    public class CreateDeskValidator : AbstractValidator<CreateDeskCommand>
    {
        public CreateDeskValidator()
        {
            RuleFor(x => x.DeskRequest.Name)
                .NotEmpty()
                .WithMessage("Nazwa biurka jest wymagana.")
                .MinimumLength(3)
                .WithMessage("Nazwa musi mieć co najmniej 3 znaki.")
                .MaximumLength(100)
                .WithMessage("Nazwa może mieć maksymalnie 100 znaków.");


            RuleFor(x => x.DeskRequest.Description)
                .MaximumLength(500)
                .WithMessage("Opis może mieć maksymalnie 500 znaków.");


            RuleFor(x => x.DeskRequest.PricePerHour)
                .GreaterThan(0)
                .WithMessage("Cena za godzinę musi być większa od 0.");


            RuleFor(x => x.DeskRequest.ChairType)
                .IsInEnum()
                .WithMessage("Wybrano nieprawidłowy typ krzesła.");
        }
    }
}