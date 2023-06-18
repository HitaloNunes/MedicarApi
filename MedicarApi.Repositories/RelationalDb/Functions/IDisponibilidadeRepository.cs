using MedicarApi.Domain.Commands.Requests;
using MedicarApi.Domain.Entities.DB;

namespace MedicarApi.Repositories.RelationalDb.Functions
{
    public interface IDisponibilidadeRepository
    {
        public void InsertNewAgendaAsync(CriarAgendaRequest request, Medico medico);
        public Task<List<Disponibilidade>> GetDisponibilidadesByDiaAndMedico(DateTime dia, Medico medico);
        public Task<Disponibilidade> GetHorario(int IdMedico, DateTime dia, TimeSpan horario);
        public Task<List<Disponibilidade>> GetHorariosDisponiveis(Medico medico, DateTime data_inicio, DateTime data_final);
        public Task FlagDisponibilidadeAsync(int id);
        public Task OpenDisponibilidadeAsync(int id);
    }
}
