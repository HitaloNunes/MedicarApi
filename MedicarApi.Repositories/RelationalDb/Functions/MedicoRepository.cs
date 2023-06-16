using MedicarApi.Domain.Entities.DB;
using MedicarApi.Repositories.RelationalDb.Context;
using Microsoft.EntityFrameworkCore;

namespace MedicarApi.Repositories.RelationalDb.Functions
{
    public class MedicoRepository : IMedicoRepository
    {
        private readonly DataContext db;

        public MedicoRepository(DataContext _db)
        {
            db = _db;
        }

        public async Task<Medico> FindByCRMAsync(string crm)
        {
            return await db.Medico.FirstOrDefaultAsync(z => z.CRM.ToLower() == crm.ToLower()) ?? new Medico();
        }

        public async void InsertNewMedicoAsync(Medico medico)
        {
            await db.Medico.AddAsync(medico);
            await db.SaveChangesAsync();
        }
    }
}