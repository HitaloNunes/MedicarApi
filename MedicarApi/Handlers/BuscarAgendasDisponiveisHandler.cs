using MediatR;
using MedicarApi.Domain.Commands.Requests;
using MedicarApi.Domain.Commands.Requests.Validations;
using MedicarApi.Domain.Commands.Responses;
using MedicarApi.Domain.Entities.DB;
using MedicarApi.Repositories.RelationalDb.Functions;
using MongoDB.Bson;

namespace MedicarApi.Handlers
{
    public class BuscarAgendasDisponiveisHandler : IRequestHandler<BuscarAgendasDisponiveisRequest, BuscarAgendasDisponiveisResponse>
    {
        private readonly IMedicoRepository medicoRepository;
        private readonly IDisponibilidadeRepository disponibilidadeRepository;
        public BuscarAgendasDisponiveisHandler(IMedicoRepository _medicoRepository, IDisponibilidadeRepository _disponibilidadeRepository)
        {
            medicoRepository = _medicoRepository;
            disponibilidadeRepository = _disponibilidadeRepository;
        }

        public async Task<BuscarAgendasDisponiveisResponse> Handle(BuscarAgendasDisponiveisRequest request, CancellationToken cancellationToken)
        {
            BuscarAgendasDisponiveisValidation validation = new BuscarAgendasDisponiveisValidation();
            BuscarAgendasDisponiveisResponse retorno = new BuscarAgendasDisponiveisResponse()
            {
                Error = new ErrorResponse()
                {
                    Validation = await validation.ValidateAsync(request)
                }
            };

            if (retorno.Error.Validation.IsValid)
            {
                List<Medico> medicos = new List<Medico>();
                if(request.medico.Count > 0)
                {
                    foreach(int idMedico in request.medico)
                    {
                        Medico medico = await medicoRepository.FindByIdAsync(idMedico);
                        if(medico.Id != 0)
                        {
                            medicos.Add(medico);
                        }
                    }
                }
                if(request.crm.Count > 0)
                {
                    foreach(string crm in request.crm)
                    {
                        Medico medico = await medicoRepository.FindByCRMAsync(crm);
                        if(medico.Id != 0)
                        {
                            medicos.Add(medico);
                        }
                    }
                }

                if(medicos.Count() > 0)
                {
                    foreach(Medico medico in medicos)
                    {
                        List<Disponibilidade> horariosDisponiveis = await disponibilidadeRepository.GetHorariosDisponiveis(medico, request.data_inicio, request.data_final);
                        if(horariosDisponiveis.Count() > 0)
                        {
                            AgendasDisponiveisResponse agenda = new AgendasDisponiveisResponse()
                            {
                                medico = new MedicoAgenda()
                                {
                                    Id = medico.Id,
                                    CRM = medico.CRM,
                                    Nome = medico.Nome,
                                    Email = medico.Email
                                }
                            };
                            foreach(Disponibilidade horario in horariosDisponiveis)
                            {
                                if(!agenda.agenda.Any(z => z.dia.Date == horario.Dia.Date))
                                {
                                    agenda.agenda.Add(new AgendaDiaria()
                                    {
                                        dia = horario.Dia.Date
                                    });
                                }
                                DateTime item = horario.Dia.Date + horario.Horario;
                                if (item > DateTime.Now)
                                {
                                    agenda.agenda[agenda.agenda.FindIndex(z => z.dia.Date == horario.Dia.Date)].horarios.Add(horario.Horario.ToString(@"hh\:mm"));
                                }

                            }

                            if(agenda.agenda.Count() > 0)
                            {
                                retorno.consulta.Add(agenda);
                            }
                        }
                    }
                } else
                {
                    retorno.Error.Description = "Nenhum médico foi encontrado. Por favor, informe a identificação ou CRM de um médico cadastrado!";
                }
            } else
            {
                retorno.Error.Description = "Por favor, verifique os filtros inseridos e tente novamente!";
            }

            return retorno;
        }
    }
}