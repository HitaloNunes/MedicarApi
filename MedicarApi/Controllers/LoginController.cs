using MedicarApi.Configuration.Authentication.Models;
using MedicarApi.Configuration.Authentication.Repositories;
using MedicarApi.Configuration.Authentication.Services;
using Microsoft.AspNetCore.Mvc;

namespace MedicarApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        [HttpPost]
        [Route("[action]")]
        public ActionResult<dynamic> Authenticate([FromBody] User login)
        {
            User user = UserRepository.Get(login.Username, login.Password);

            if(user.Username == "Usuário Inválido")
            {
                return BadRequest(new { Message = "Usuário ou senha inválidos!" });
            } else
            {
                string token = TokenService.GenerateToken(user);

                user.Password = "";
                return Ok(new
                {
                    user = user,
                    token = token
                });
            }
        }
    }
}