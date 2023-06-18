using MediatR;

namespace MedicarApi.Domain.Commands.Requests
{
    public class DesmarcarConsultaRequest : IRequest<string>
    {
        public string Id { get; set; } = string.Empty;
    }
}
