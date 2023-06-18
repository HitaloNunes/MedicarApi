using MediatR;
using MedicarApi.Domain.Entities.NoSql;

namespace MedicarApi.Domain.Commands.Requests
{
    public class BuscarConsultasMarcadasRequest : IRequest<List<Consulta>>
    {
    }
}
