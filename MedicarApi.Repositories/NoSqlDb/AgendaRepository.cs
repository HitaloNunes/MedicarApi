using MedicarApi.Domain.Entities.NoSql;
using MongoDB.Driver;

namespace MedicarApi.Repositories.NoSqlDb
{
    public class AgendaRepository : IAgendaRepository
    {
        private readonly IMongoCollection<Agenda> agendaCollection;

        private static string ConnectionString = "mongodb://admin:abcd.1234@localhost:27017";
        private static string DatabaseName = "";
        private static string CollectionName = "";

        public AgendaRepository()
        {
            MongoClient mongoClient = new MongoClient(ConnectionString);
            IMongoDatabase mongoDatabase = mongoClient.GetDatabase(DatabaseName);
            agendaCollection = mongoDatabase.GetCollection<Agenda>(CollectionName);
        }
    }
}