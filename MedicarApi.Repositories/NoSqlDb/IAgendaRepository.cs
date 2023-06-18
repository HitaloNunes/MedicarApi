using MedicarApi.Domain.Entities.NoSql;

namespace MedicarApi.Repositories.NoSqlDb
{
    public interface IAgendaRepository
    {
        public Task<Consulta> GetConsulta(string id);
        public Task SaveConsulta(Consulta consulta);
        public Task DeleteConsulta(string id);
    }
}
