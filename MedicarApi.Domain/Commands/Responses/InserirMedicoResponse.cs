using FluentValidation.Results;

namespace MedicarApi.Domain.Commands.Responses
{
    public class InserirMedicoResponse
    {
        public string Status { get; set; } = string.Empty;
        public ValidationResult Validation { get; set; } = new ValidationResult();
    }
}
