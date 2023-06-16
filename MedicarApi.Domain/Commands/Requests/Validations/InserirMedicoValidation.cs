using FluentValidation;

namespace MedicarApi.Domain.Commands.Requests.Validations
{
    public class InserirMedicoValidation : AbstractValidator<InserirMedicoRequest>
    {
        public InserirMedicoValidation()
        {
            RuleFor(p => p.Nome)
                .NotEmpty()
                .WithMessage("Campo Obrigatório");

            RuleFor(p => p.CRM)
                .NotEmpty()
                .WithMessage("Campo Obrigatório");

            RuleFor(p => p.Email)
                .NotEmpty()
                .WithMessage("Campo Obrigatório");
        }
    }
}
