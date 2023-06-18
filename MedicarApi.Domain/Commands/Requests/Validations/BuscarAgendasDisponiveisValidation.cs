using FluentValidation;

namespace MedicarApi.Domain.Commands.Requests.Validations
{
    public class BuscarAgendasDisponiveisValidation : AbstractValidator<BuscarAgendasDisponiveisRequest>
    {
        public BuscarAgendasDisponiveisValidation()
        {
            RuleFor(p => p.data_inicio)
                .NotEmpty()
                .WithMessage("É necessário informar o início do período de consulta!")
                .GreaterThanOrEqualTo(DateTime.Now.Date)
                .WithMessage("O início do período precisa ser no futuro!");

            RuleFor(p => p.data_final)
                .NotEmpty()
                .WithMessage("É necessário informar o fim do período de consulta!")
                .GreaterThanOrEqualTo(DateTime.Now.Date)
                .WithMessage("O fim do período precisa ser no futuro!")
                .GreaterThanOrEqualTo(p => p.data_inicio)
                .WithMessage("O fim do período precisa ser posterior ou no mesmo dia do período inicial!");
        }
    }
}
