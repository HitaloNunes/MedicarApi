namespace MedicarApi.Domain.Entities.DB
{
    public class Medico : Entity
    {
        public string Nome { get; set; } = string.Empty;
        public string CRM { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public virtual ICollection<Disponibilidade> Agenda { get; set; } = new List<Disponibilidade>();

    }
}
