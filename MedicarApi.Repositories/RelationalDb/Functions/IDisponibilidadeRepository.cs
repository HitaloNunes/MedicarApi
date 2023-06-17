using MedicarApi.Domain.Commands.Requests;
using MedicarApi.Domain.Entities.DB;

namespace MedicarApi.Repositories.RelationalDb.Functions
{
    public interface IDisponibilidadeRepository
    {
        public void InsertNewAgendaAsync(CriarAgendaRequest request, Medico medico);
        public Task<List<Disponibilidade>> GetDisponibilidadesByDiaAndMedico(DateTime dia, Medico medico);
    }
}
