using MedicarApi.Domain.Entities.DB;

namespace MedicarApi.Repositories.RelationalDb.Functions
{
    public interface IMedicoRepository
    {
        public Task<Medico> FindByCRMAsync(string crm);
        public void InsertNewMedicoAsync(Medico medico);
    }
}
