using System.Text.Json.Serialization;

namespace MedicarApi.Domain.Entities.DB
{
    public class Medico : Entity
    {
        public string Nome { get; set; } = string.Empty;
        public string CRM { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;

        [JsonIgnore]
        public virtual ICollection<Disponibilidade>? Disponibilidade { get; set; }

    }
}
