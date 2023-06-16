using MedicarApi.Domain.Entities.DB;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace MedicarApi.Domain.Entities.NoSql
{
    public class Agenda
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }
        public Medico Medico { get; set; } = new Medico();
        public DateTime DtAgendamento { get; set; } = DateTime.Now;
        public DateTime Dia { get; set; } = DateTime.Now;
        public List<TimeSpan> Consultas { get; set; } = new List<TimeSpan>();
    }
}