using MediatR;
using MedicarApi.Domain.Commands.Requests;
using MedicarApi.Domain.Commands.Requests.Validations;
using MedicarApi.Domain.Commands.Responses;
using MedicarApi.Domain.Entities.DB;
using MedicarApi.Domain.Entities.NoSql;
using MedicarApi.Repositories.NoSqlDb;
using MedicarApi.Repositories.RelationalDb.Functions;

namespace MedicarApi.Handlers
{
    public class MarcarConsultaHandler : IRequestHandler<MarcarConsultaRequest, MarcarConsultaResponse>
    {
        private readonly IMedicoRepository medicoRepository;
        private readonly IDisponibilidadeRepository disponibilidadeRepository;
        private readonly IAgendaRepository agendaRepository;
        public MarcarConsultaHandler(IMedicoRepository _medicoRepository, IDisponibilidadeRepository _disponibilidadeRepository, IAgendaRepository _agendaRepository)
        {
            medicoRepository = _medicoRepository;
            disponibilidadeRepository = _disponibilidadeRepository;
            agendaRepository = _agendaRepository;
        }

        public async Task<MarcarConsultaResponse> Handle(MarcarConsultaRequest request, CancellationToken cancellationToken)
        {
            MarcarConsultaValidation validation = new MarcarConsultaValidation();
            MarcarConsultaResponse retorno = new MarcarConsultaResponse()
            {
                Error = new Error()
                {
                    Validation = await validation.ValidateAsync(request)
                }
            };
            if (retorno.Error.Validation.IsValid)
            {
                if(request.dia.Date == DateTime.Now.Date && DateTime.Now.TimeOfDay > TimeSpan.Parse(request.horario))
                {
                    retorno.Error.Description = "A consulta não pode ser marcada no passado!";
                } else
                {
                    Medico medico = await medicoRepository.FindByIdAsync(request.medico_id);
                    if (medico.Id == 0)
                    {
                        retorno.Error.Description = "Medico não encontrado!";
                    }
                    else
                    {
                        List<Disponibilidade> disponibilidade = await disponibilidadeRepository.GetDisponibilidadesByDiaAndMedico(request.dia, medico);
                        if (disponibilidade.Count() > 0)
                        {
                            if (disponibilidade.Any(z => z.Horario == TimeSpan.Parse(request.horario) && z.Disponivel))
                            {
                                Consulta consulta = new Consulta()
                                {
                                    medico = new MedicoConsulta()
                                    {
                                        Id = medico.Id,
                                        Nome = medico.Nome,
                                        CRM = medico.CRM,
                                        Email = medico.Email
                                    },
                                    data_agendamento = DateTime.Now,
                                    dia = request.dia,
                                    horario = request.horario
                                };

                                await agendaRepository.SaveConsulta(consulta);
                                await disponibilidadeRepository.FlagDisponibilidadeAsync(
                                    disponibilidade
                                    [disponibilidade.FindIndex(z => z.Horario == TimeSpan.Parse(request.horario) && z.Disponivel)]
                                    .Id);
                                retorno.Consulta = consulta;
                            }
                            else
                            {
                                retorno.Error.Description = "O horário solicitado não está disponível!";
                            }
                        }
                        else
                        {
                            retorno.Error.Description = "O dia solicitado não está disponível!";
                        }
                    }
                }
            } else
            {
                retorno.Error.Description = "Por favor, verifique os dados enviados e tente novamente!";
            }

            return retorno;
        }
    }
}
