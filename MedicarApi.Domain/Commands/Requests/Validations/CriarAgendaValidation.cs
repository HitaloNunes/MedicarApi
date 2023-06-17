using FluentValidation;
using System.Runtime.CompilerServices;

namespace MedicarApi.Domain.Commands.Requests.Validations
{
    public class CriarAgendaValidation : AbstractValidator<CriarAgendaRequest>
    {
        public CriarAgendaValidation()
        {
            RuleFor(p => p.CRM)
                .NotEmpty()
                .WithMessage("O médico precisa ser identificado!");

            RuleFor(p => p.Dia)
                .GreaterThanOrEqualTo(DateTime.Now.Date)
                .WithMessage("Não é permitido criar uma agenda no passado.");

            RuleFor(p => p.Horarios)
                .NotEmpty()
                .WithMessage("Informe os horários para a criação da agenda.");
        }
    }
}