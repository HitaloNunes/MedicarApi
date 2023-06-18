using FluentValidation.Results;

namespace MedicarApi.Domain.Commands.Responses
{
    public class ErrorResponse
    {
        public string Description { get; set; } = string.Empty;
        public ValidationResult Validation { get; set; } = new ValidationResult();
    }
}
