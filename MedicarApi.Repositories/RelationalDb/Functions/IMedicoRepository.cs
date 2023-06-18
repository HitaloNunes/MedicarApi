using MedicarApi.Domain.Entities.DB;

namespace MedicarApi.Repositories.RelationalDb.Functions
{
    public interface IMedicoRepository
    {
        public Task<Medico> FindByIdAsync(int id);
        public Task<Medico> FindByCRMAsync(string crm);
        public void InsertNewMedicoAsync(Medico medico);
    }
}
