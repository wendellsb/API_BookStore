using API_BookStore.DTO.Usuario;
using API_BookStore.Model;
using API_BookStore.Services.Usuario;
using Microsoft.AspNetCore.Mvc;

namespace API_BookStore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioInterface _usuarioInterface;
        public UsuarioController(IUsuarioInterface usuarioInterface)
        {
            _usuarioInterface = usuarioInterface;
        }

        [HttpPost("Registrar")]
        public async Task<ActionResult<ResponseModel<UsuarioModel>>> Registrar(UsuarioCriacaoDto usuarioCriacao)
        {
            var usuario = await _usuarioInterface.Registrar(usuarioCriacao);
            return Ok(usuario);
        }

        [HttpPost("Login")]
        public async Task<ActionResult<ResponseModel<UsuarioModel>>> Login(UsuarioLoginDto usuarioLogin)
        {
            var usuario = await _usuarioInterface.Login(usuarioLogin);
            return Ok(usuario);
        }

    }
}
