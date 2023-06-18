using MedicarApi.Domain.Entities.NoSql;

namespace MedicarApi.Repositories.NoSqlDb
{
    public interface IAgendaRepository
    {
        public Task SaveConsulta(Consulta consulta);
    }
}
