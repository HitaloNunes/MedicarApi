using MediatR;
using MedicarApi.Domain.Commands.Requests;
using MedicarApi.Domain.Entities.NoSql;
using MedicarApi.Repositories.NoSqlDb;

namespace MedicarApi.Handlers
{
    public class BuscarConsultasMarcadasHandler : IRequestHandler<BuscarConsultasMarcadasRequest, List<Consulta>>
    {
        private readonly IAgendaRepository agendaRepository;
        public BuscarConsultasMarcadasHandler(IAgendaRepository _agendaRepository)
        {
            agendaRepository = _agendaRepository;
        }

        public async Task<List<Consulta>> Handle(BuscarConsultasMarcadasRequest request, CancellationToken cancellationToken)
        {
            List<Consulta> consultas = await agendaRepository.GetConsultas();
            return consultas.Where(z => z.dia.Date + TimeSpan.Parse(z.horario) >= DateTime.Now).OrderBy(z => z.dia + TimeSpan.Parse(z.horario)).ToList();
        }
    }
}
