using MediatR;
using MedicarApi.Domain.Entities.NoSql;

namespace MedicarApi.Domain.Commands
{
    public class BuscarConsultasMarcadasRequest : IRequest<List<Consulta>>
    {
    }
}
