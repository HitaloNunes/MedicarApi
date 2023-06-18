using MedicarApi.Domain.Entities.DB;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace MedicarApi.Domain.Entities.NoSql
{
    public class Consulta
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? id { get; set; }
        public MedicoConsulta medico { get; set; } = new MedicoConsulta();
        public DateTime data_agendamento { get; set; } = DateTime.Now;
        public DateTime dia { get; set; } = DateTime.Now;
        public string horario { get; set; } = string.Empty;
    }

    public class MedicoConsulta
    {
        public int Id { get; set; }
        public string Nome { get; set; } = string.Empty;
        public string CRM { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
    }
}