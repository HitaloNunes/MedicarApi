using MediatR;
using MedicarApi.Domain.Commands.Responses;

namespace MedicarApi.Domain.Commands.Requests
{
    public class InserirMedicoRequest : IRequest<InserirMedicoResponse>
    {
        public string Nome { get; set; } = string.Empty;
        public string CRM { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
    }
}
