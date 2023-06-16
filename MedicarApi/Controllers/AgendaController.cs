using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MedicarApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AgendaController : ControllerBase
    {
        [HttpGet]
        [Route("[action]")]
        [Authorize(Roles = "Hokage, Nurse")]
        public ActionResult Consultas()
        {
            return Ok();
        }
    }
}
