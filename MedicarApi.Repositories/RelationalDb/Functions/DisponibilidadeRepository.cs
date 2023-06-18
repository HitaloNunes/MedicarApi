using MedicarApi.Domain.Commands.Requests;
using MedicarApi.Domain.Entities.DB;
using MedicarApi.Repositories.RelationalDb.Context;
using Microsoft.EntityFrameworkCore;

namespace MedicarApi.Repositories.RelationalDb.Functions
{
    public class DisponibilidadeRepository : IDisponibilidadeRepository
    {
        private readonly DataContext db;
        public DisponibilidadeRepository(DataContext _db)
        {
            db = _db;
        }

        public async void InsertNewAgendaAsync(CriarAgendaRequest request, Medico medico)
        {
            foreach(string horario in request.Horarios)
            {
                await db.Disponibilidade.AddAsync(new Disponibilidade()
                {
                    IdMedico = medico.Id,
                    Dia = request.Dia,
                    Horario = TimeSpan.Parse(horario)
                });
            }

            await db.SaveChangesAsync();
        }

        public async Task<List<Disponibilidade>> GetDisponibilidadesByDiaAndMedico(DateTime dia, Medico medico)
        {
            List<Disponibilidade> retorno = await db.Disponibilidade.Where(z => z.Dia == dia && z.IdMedico == medico.Id).ToListAsync();
            return retorno;
        }

        public async Task<Disponibilidade> GetHorario(int IdMedico, DateTime dia, TimeSpan horario)
        {
            return await db.Disponibilidade.FirstOrDefaultAsync(z => z.IdMedico == IdMedico && z.Dia == dia && z.Horario == horario) ?? new Disponibilidade();
        }

        public async Task<List<Disponibilidade>> GetHorariosDisponiveis(Medico medico, DateTime data_inicio, DateTime data_final)
        {
            List<Disponibilidade> disponibilidades = await db.Disponibilidade
                .Where(z => z.IdMedico == medico.Id 
                && (z.Dia.Date >= data_inicio.Date && z.Dia.Date <= data_final.Date)
                && z.Disponivel)
                .OrderBy(z => z.Dia)
                .ThenBy(z => z.Horario)
                .ToListAsync();

            return disponibilidades;
        }

        public async Task FlagDisponibilidadeAsync(int id)
        {
            Disponibilidade disponibilidade = await db.Disponibilidade.FindAsync(id) ?? new Disponibilidade();
            disponibilidade.Disponivel = false;
            db.Disponibilidade.Update(disponibilidade);
            await db.SaveChangesAsync();
        }

        public async Task OpenDisponibilidadeAsync(int id)
        {
            Disponibilidade disponibilidade = await db.Disponibilidade.FindAsync(id) ?? new Disponibilidade();
            disponibilidade.Disponivel = true;
            db.Disponibilidade.Update(disponibilidade);
            await db.SaveChangesAsync();
        }
    }
}
