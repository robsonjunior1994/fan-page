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
        private readonly IUsuarioService _usuarioService;
        public PerfilController(IPublicacaoService publicacaoService, IUsuarioService usuarioService)
        {
            _publicacaoService = publicacaoService;
            _usuarioService= usuarioService;
        }

        [HttpGet]
        [Route("Usuario/{nomeDoUsuario}")]
        public ActionResult Perfil(string nomeDoUsuario)
        {
            //Verificar se usuário assina esse perfil, se não redirecionar para página de assinatura
            //Pegar usuário junto com a foto de perfil
            var usuario = _usuarioService.PegarUsuarioPorNomeDeUsuario(nomeDoUsuario);
            //Pegar fotos publicadas no seu perfil
            var listaDeFotos = _publicacaoService.PegarFotosPublicadasNoPerfil(usuario.Id);
            //Pegar lista de seguidores
            //Pegar lista de quem ele segue

            return Ok(new {FotoDePerfil = usuario.ImagemDoPerfil, ListaDeFotos = listaDeFotos });
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
