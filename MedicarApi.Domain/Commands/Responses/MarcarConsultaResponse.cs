using FluentValidation.Results;
using MedicarApi.Domain.Entities.NoSql;

namespace MedicarApi.Domain.Commands.Responses
{
    public class MarcarConsultaResponse
    {
        public Consulta Consulta { get; set; } = new Consulta();
        public Error Error { get; set; } = new Error();
    }

    public class Error
    {
        public string Description { get; set; } = string.Empty;
        public ValidationResult Validation { get; set; } = new ValidationResult();
    }
}
