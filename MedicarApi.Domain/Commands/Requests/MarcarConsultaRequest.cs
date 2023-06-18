using MediatR;
using MedicarApi.Domain.Commands.Responses;

namespace MedicarApi.Domain.Commands.Requests
{
    public class MarcarConsultaRequest : IRequest<MarcarConsultaResponse>
    {
        public int medico_id { get; set; }
        public DateTime dia { get; set; } = new DateTime();
        public string horario { get; set; } = string.Empty;
    }
}
