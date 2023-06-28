using fan_page.Models;
using fan_page.Request;
using fan_page.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace fan_page.Controllers
{
    [Route("api/[controller]/")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioService _usuarioService;
        public UsuarioController(IUsuarioService usuarioService)
        {
            _usuarioService = usuarioService;
        }

        [HttpPost]
        [Route("Criar")]
        [Consumes("multipart/form-data")]
        public ActionResult Create([FromForm] Usuario usuario, IFormFile imageFile)
        {
            if (imageFile == null || imageFile.Length <= 0)
            {
                return BadRequest("Nenhuma imagem foi enviada.");
            }

            _usuarioService.Criar(usuario, imageFile);

            return Ok();
        }

        [HttpPost]
        [Route("FazerLogin")]
        public ActionResult FazerLogin(Login login)
        {
            string token = _usuarioService.FazerLogin(login);

            return Ok(new {Token = token});
        }
    }
}

