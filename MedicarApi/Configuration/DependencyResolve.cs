using MedicarApi.Repositories.NoSqlDb;
using MedicarApi.Repositories.RelationalDb.Context;
using MedicarApi.Repositories.RelationalDb.Functions;

namespace MedicarApi.Configuration
{
    public class DependencyResolve
    {
        public void ConfigureServices(IServiceCollection services)
        {
            #region Validation

            #endregion
            #region Repository
            services.AddSingleton<DataContext>();
            services.AddScoped<IMedicoRepository, MedicoRepository>();
            services.AddScoped<IAgendaRepository, AgendaRepository>();
            #endregion
        }
    }
}
