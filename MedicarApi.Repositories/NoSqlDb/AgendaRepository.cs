using MedicarApi.Domain.Entities.NoSql;
using MongoDB.Driver;

namespace MedicarApi.Repositories.NoSqlDb
{
    public class AgendaRepository : IAgendaRepository
    {
        private readonly IMongoCollection<Consulta> agendaCollection;

        private static string ConnectionString = "mongodb://admin:abcd.1234@localhost:27017";
        private static string DatabaseName = "MedicarNoSql";
        private static string CollectionName = "Consultas";

        public AgendaRepository()
        {
            MongoClient mongoClient = new MongoClient(ConnectionString);
            IMongoDatabase mongoDatabase = mongoClient.GetDatabase(DatabaseName);
            agendaCollection = mongoDatabase.GetCollection<Consulta>(CollectionName);
        }

        public async Task SaveConsulta(Consulta consulta)
        {
            await agendaCollection.InsertOneAsync(consulta);
        }
    }
}