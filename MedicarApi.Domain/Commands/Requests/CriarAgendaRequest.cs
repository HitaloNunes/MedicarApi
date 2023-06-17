using MediatR;
using MedicarApi.Domain.Commands.Responses;

namespace MedicarApi.Domain.Commands.Requests
{
    public class CriarAgendaRequest : IRequest<CriarAgendaResponse>
    {
        public string CRM { get; set; } = string.Empty;
        public DateTime Dia { get; set; } = DateTime.Now;
        public List<string> Horarios { get; set; } = new List<string>();
    }
}