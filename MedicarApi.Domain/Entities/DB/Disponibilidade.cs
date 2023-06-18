namespace MedicarApi.Domain.Entities.DB
{
    public class Disponibilidade : Entity
    {
        public int IdMedico { get; set; }
        public bool Disponivel { get; set; } = true;
        public DateTime Dia { get; set; } = new DateTime();
        public TimeSpan Horario { get; set; }
        public virtual Medico? Medico { get; set; }
    }
}