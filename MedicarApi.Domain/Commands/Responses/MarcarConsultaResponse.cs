using MedicarApi.Domain.Entities.NoSql;

namespace MedicarApi.Domain.Commands.Responses
{
    public class MarcarConsultaResponse
    {
        public Consulta Consulta { get; set; } = new Consulta();
        public ErrorResponse Error { get; set; } = new ErrorResponse();
    }
}
