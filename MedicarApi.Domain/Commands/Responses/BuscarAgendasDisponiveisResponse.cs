namespace MedicarApi.Domain.Commands.Responses
{
    public class BuscarAgendasDisponiveisResponse
    {
        public List<AgendasDisponiveisResponse> consulta { get; set; } = new List<AgendasDisponiveisResponse>();
        public ErrorResponse Error { get; set; } = new ErrorResponse();
    }

    public class AgendasDisponiveisResponse
    {
        public MedicoAgenda medico { get; set; } = new MedicoAgenda();
        public List<AgendaDiaria> agenda { get; set; } = new List<AgendaDiaria>();
    }

    public class AgendaDiaria
    {
        public DateTime dia { get; set; } = DateTime.Now;
        public List<string> horarios { get; set; } = new List<string>();
    }

    public class MedicoAgenda
    {
        public int Id { get; set; }
        public string CRM { get; set; } = string.Empty;
        public string Nome { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
    }
}
