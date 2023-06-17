using FluentValidation.Results;

namespace MedicarApi.Domain.Commands.Responses
{
    public class CriarAgendaResponse
    {
        public MedicoResponse Medico { get; set; } = new MedicoResponse();
        public string Status { get; set; } = string.Empty;
        public ValidationResult Validation { get; set; } = new ValidationResult();
    }

    public class MedicoResponse
    {
        public string Nome { get; set; } = string.Empty;
        public string CRM { get; set; } = string.Empty;
    }
}