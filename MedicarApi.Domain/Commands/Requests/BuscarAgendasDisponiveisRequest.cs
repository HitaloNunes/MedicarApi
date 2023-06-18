using MediatR;
using MedicarApi.Domain.Commands.Responses;

namespace MedicarApi.Domain.Commands.Requests
{
    public class BuscarAgendasDisponiveisRequest : IRequest<BuscarAgendasDisponiveisResponse>
    {
        public List<int> medico { get; set; } = new List<int>();
        public List<string> crm { get; set; } = new List<string>();
        public DateTime data_inicio { get; set; } = new DateTime();
        public DateTime data_final { get; set; } = new DateTime();
    }
}
