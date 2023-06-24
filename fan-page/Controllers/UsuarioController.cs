using fan_page.Models;
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
        public async Task<ActionResult> Create([FromForm] Usuario usuario, IFormFile imageFile)
        {
            if (imageFile == null || imageFile.Length <= 0)
            {
                return BadRequest("Nenhuma imagem foi enviada.");
            }

            _usuarioService.CriarAsync(usuario, imageFile);

            return Ok();
        }

        [HttpPost]
        [Route("foto")]
        public async Task<ActionResult> Foto(IFormFile imageFile)
        {
            if (imageFile == null || imageFile.Length <= 0)
            {
                return BadRequest("Nenhuma imagem foi enviada.");
            }

            // Gere um nome de arquivo único para a imagem
            string fileName = Guid.NewGuid().ToString() + Path.GetExtension(imageFile.FileName);

            // Determine o caminho completo para salvar a imagem
            string filePath = Path.Combine("C:\\projetos\\fan-page\\fan-page\\Midias\\FotoDePerfil", fileName);

            // Salve a imagem no disco
            using (var fileStream = new FileStream(filePath, FileMode.Create))
            {
                await imageFile.CopyToAsync(fileStream);
            }

            return Ok();
        }
    }
}

