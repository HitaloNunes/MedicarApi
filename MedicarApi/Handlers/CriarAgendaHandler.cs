using MediatR;
using MedicarApi.Domain.Commands.Requests;
using MedicarApi.Domain.Commands.Requests.Validations;
using MedicarApi.Domain.Commands.Responses;
using MedicarApi.Domain.Entities.DB;
using MedicarApi.Repositories.RelationalDb.Functions;

namespace MedicarApi.Handlers
{
    public class CriarAgendaHandler : IRequestHandler<CriarAgendaRequest, CriarAgendaResponse>
    {
        private readonly IDisponibilidadeRepository disponibilidadeRepository;
        private readonly IMedicoRepository medicoRepository;
        public CriarAgendaHandler(IDisponibilidadeRepository _disponibilidadeRepository, IMedicoRepository _medicoRepository)
        {
            disponibilidadeRepository = _disponibilidadeRepository;
            medicoRepository = _medicoRepository;
        }

        public async Task<CriarAgendaResponse> Handle(CriarAgendaRequest request, CancellationToken cancellationToken)
        {
            CriarAgendaValidation validation = new CriarAgendaValidation();
            CriarAgendaResponse retorno = new CriarAgendaResponse()
            {
                Validation = await validation.ValidateAsync(request)
            };
            if(retorno.Validation.IsValid)
            {
                Medico medico = await medicoRepository.FindByCRMAsync(request.CRM);
                if(medico.Id != 0)
                {
                    retorno.Medico.CRM = medico.CRM;
                    retorno.Medico.Nome = medico.Nome;
                    List<Disponibilidade> disponibilidade = await disponibilidadeRepository.GetDisponibilidadesByDiaAndMedico(request.Dia, medico);
                    if(disponibilidade.Count == 0)
                    {
                        disponibilidadeRepository.InsertNewAgendaAsync(request, medico);
                        retorno.Status = "Agenda criada com sucesso!";
                    } else
                    {
                        retorno.Status = $"O doutor(a) { medico.Nome } já possui uma agenda para esse dia!";
                    }
                } else
                {
                    retorno.Status = "Médico não cadastrado!";
                }
            }
            else
            {
                retorno.Status = "Não foi possível criar a agenda!";
            }


            return retorno;
        }
    }
}
