using fan_page.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace fan_page.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PerfilController : ControllerBase
    {
        private readonly IPublicacaoService _publicacaoService;
        public PerfilController(IPublicacaoService publicacaoService)
        {
            _publicacaoService = publicacaoService;
        }

        [Route("")]
        [HttpGet]
        public ActionResult Perfil()
        {
            //vai retornar as publicas, os seguidores, e quem ele segue 
            //aqui vai ficar o campo disponível para ele fazer publicações
            return Ok();
        }

        [Route("Publicar")]
        [HttpPost]
        public ActionResult Publicar([FromForm] string texto, IFormFile imagem)
        {
            HttpContext.Request.Headers.TryGetValue("usuarioToken", out var usuarioToken);

            _publicacaoService.Publicar(usuarioToken, texto, imagem);

            return Ok();
        }
    }
}
