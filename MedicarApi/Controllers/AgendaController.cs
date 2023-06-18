using MediatR;
using MedicarApi.Domain.Commands.Requests;
using MedicarApi.Domain.Commands.Responses;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MedicarApi.Controllers
{
    [Route("")]
    [ApiController]
    public class AgendaController : ControllerBase
    {
        private readonly IMediator mediator;
        public AgendaController(IMediator _mediator)
        {
            mediator = _mediator;
        }

        [HttpGet]
        [Route("consultas/")]
        [Authorize(Roles = "Hokage, Nurse, Boss")]
        public async Task<ActionResult> ConsultasMarcadas(BuscarConsultasMarcadasRequest request)
        {
            return Ok(await mediator.Send(request));
        }

        [HttpGet]
        [Route("agendas")]
        [Authorize(Roles = "Hokage, Nurse, Boss")]
        public async Task<ActionResult> AgendasDisponiveis([FromQuery] BuscarAgendasDisponiveisRequest request)
        {
            BuscarAgendasDisponiveisResponse response = await mediator.Send(request);
            if (string.IsNullOrEmpty(response.Error.Description))
            {
                return Ok(response.consulta);
            } else
            {
                return BadRequest(response.Error);
            }
        }

        [HttpPost]
        [Route("consultas/")]
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
        [Route("consultas/{id}")]
        [Authorize(Roles = "Hokage, Nurse")]
        public async Task<ActionResult> DesmarcarConsulta([FromRoute] DesmarcarConsultaRequest request)
        {
            string response = await mediator.Send(request);
            return Ok();
        }
    }
}
