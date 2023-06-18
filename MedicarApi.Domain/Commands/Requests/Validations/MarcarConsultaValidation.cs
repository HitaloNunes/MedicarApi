using FluentValidation;

namespace MedicarApi.Domain.Commands.Requests.Validations
{
    public class MarcarConsultaValidation : AbstractValidator<MarcarConsultaRequest>
    {
        public MarcarConsultaValidation()
        {
            RuleFor(p => p.medico_id)
                .NotEmpty()
                .WithMessage("O medico deve ser informado!");

            RuleFor(p => p.dia)
                .NotEmpty()
                .WithMessage("A data da consulta deve ser informada!")
                .GreaterThanOrEqualTo(DateTime.Now.Date)
                .WithMessage("Consultas não podem ser marcadas no passado!");                

            RuleFor(p => p.horario)
                .NotEmpty()
                .WithMessage("O horário deve ser informado!");
        }
    }
}
