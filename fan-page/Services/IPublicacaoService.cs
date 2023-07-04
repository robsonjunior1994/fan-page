using fan_page.Models;

namespace fan_page.Services
{
    public interface IPublicacaoService
    {
        IEnumerable<Publicacao> PegarFotosPublicadasNoPerfil(int id);
        void Publicar(string tokenUsuario, string texto, IFormFile imagem);
    }
}
