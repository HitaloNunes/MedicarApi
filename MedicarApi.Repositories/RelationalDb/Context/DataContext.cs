using MedicarApi.Domain.Entities.DB;
using MedicarApi.Repositories.RelationalDb.Mappings;
using Microsoft.EntityFrameworkCore;

namespace MedicarApi.Repositories.RelationalDb.Context
{
    public class DataContext : DbContext
    {
        public DataContext()
        {

        }

        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=localhost;Database=MedicarDb;User Id=sa;Password=abcd.1234;Trust Server Certificate=true");
        }

        public virtual DbSet<Medico> Medico { get; set; }
        public virtual DbSet<Disponibilidade> Disponibilidade { get; set; }

        protected override void OnModelCreating(ModelBuilder model)
        {
            model.ApplyConfiguration(new MedicoMapping());
            model.ApplyConfiguration(new DisponibilidadeMapping());
        }
    }
}
