using MedicarApi.Domain.Commands.Requests.Validations;
using MedicarApi.Domain.Commands.Requests;
using MedicarApi.Domain.Commands.Responses;
using MedicarApi.Domain.Entities.DB;
using MedicarApi.Repositories.RelationalDb.Functions;
using MediatR;

namespace MedicarApi.Handlers
{
    public class InserirMedicoHandler : IRequestHandler<InserirMedicoRequest, InserirMedicoResponse>
    {
        private readonly IMedicoRepository medicoRepository;
        public InserirMedicoHandler(IMedicoRepository _medicoRepository)
        {
            medicoRepository = _medicoRepository;
        }

        public async Task<InserirMedicoResponse> Handle(InserirMedicoRequest request, CancellationToken cancellationToken)
        {
            InserirMedicoValidation validation = new InserirMedicoValidation();
            InserirMedicoResponse retorno = new InserirMedicoResponse()
            {
                Validation = await validation.ValidateAsync(request)
            };
            if (retorno.Validation.IsValid)
            {
                Medico medico = await medicoRepository.FindByCRMAsync(request.CRM);
                if (medico.Id == 0)
                {
                    medico.Nome = request.Nome;
                    medico.Email = request.Email;
                    medico.CRM = request.CRM;
                    medicoRepository.InsertNewMedicoAsync(medico);
                    retorno.Status = "Medico cadastrado com sucesso!";
                }
                else
                {
                    retorno.Status = "CRM já cadastrado!";
                }
            }
            else
            {
                retorno.Status = "Não foi possível inserir o médico!";
            }

            return retorno;
        }
    }
}
