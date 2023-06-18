using MediatR;
using MedicarApi.Domain.Commands;
using MedicarApi.Domain.Commands.Requests;
using MedicarApi.Domain.Commands.Responses;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MedicarApi.Controllers
{
    [Route("consultas")]
    [ApiController]
    public class AgendaController : ControllerBase
    {
        private readonly IMediator mediator;
        public AgendaController(IMediator _mediator)
        {
            mediator = _mediator;
        }

        [HttpGet]
        [Route("")]
        [Authorize(Roles = "Hokage, Nurse, Boss")]
        public async Task<ActionResult> ConsultasMarcadas(BuscarConsultasMarcadasRequest request)
        {
            return Ok(await mediator.Send(request));
        }

        [HttpPost]
        [Route("")]
        [Authorize(Roles = "Hokage, Nurse")]
        public async Task<ActionResult> MarcarConsulta([FromBody] MarcarConsultaRequest request)
        {
            MarcarConsultaResponse response = await mediator.Send(request);
            if (string.IsNullOrEmpty(response.Error.Description))
            {
                return Ok(response.Consulta);
            } else
            {
                return BadRequest(response.Error);
            }
        }

        [HttpDelete]
        [Route("{id}")]
        [Authorize(Roles = "Hokage, Nurse")]
        public async Task<ActionResult> DesmarcarConsulta([FromRoute] DesmarcarConsultaRequest request)
        {
            string response = await mediator.Send(request);
            return Ok();
        }
    }
}
