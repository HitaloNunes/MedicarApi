using MediatR;
using MedicarApi.Domain.Commands.Requests;
using MedicarApi.Domain.Commands.Responses;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MedicarApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class MedicoController : ControllerBase
    {
        private readonly IMediator mediator;
        public MedicoController(IMediator _mediator)
        {
            mediator = _mediator;
        }

        [HttpPost]
        [Route("[action]")]
        [Authorize(Roles = "Hokage, Boss")]
        public async Task<ActionResult> InserirMedico(InserirMedicoRequest request)
        {
            InserirMedicoResponse response = await mediator.Send(request);
            if(response.Status == "Medico cadastrado com sucesso!")
            {
                return Ok(response);
            } else
            {
                return BadRequest(response);
            }
        }

        [HttpPost]
        [Route("[action]")]
        [Authorize(Roles = "Hokage, Boss")]
        public ActionResult CriarAgenda()
        {
            return Ok();
        }
    }
}