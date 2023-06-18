using MediatR;
using MedicarApi.Domain.Commands.Requests;
using MedicarApi.Domain.Entities.DB;
using MedicarApi.Domain.Entities.NoSql;
using MedicarApi.Repositories.NoSqlDb;
using MedicarApi.Repositories.RelationalDb.Functions;

namespace MedicarApi.Handlers
{
    public class DesmarcarConsultaHandler : IRequestHandler<DesmarcarConsultaRequest, string>
    {
        private readonly IAgendaRepository agendaRepository;
        private readonly IDisponibilidadeRepository disponibilidadeRepository;
        public DesmarcarConsultaHandler(IAgendaRepository _agendaRepository, IDisponibilidadeRepository _disponibilidadeRepository)
        {
            agendaRepository = _agendaRepository;
            disponibilidadeRepository = _disponibilidadeRepository;
        }

        public async Task<string> Handle(DesmarcarConsultaRequest request, CancellationToken cancellationToken)
        {
            Consulta consulta = await agendaRepository.GetConsulta(request.Id);
            Disponibilidade horario = await disponibilidadeRepository.GetHorario(consulta.medico.Id, consulta.dia.Date, TimeSpan.Parse(consulta.horario));
            await disponibilidadeRepository.OpenDisponibilidadeAsync(horario.Id);
            await agendaRepository.DeleteConsulta(request.Id);
            return string.Empty;
        }
    }
}
