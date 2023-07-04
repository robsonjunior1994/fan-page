using fan_page.Models;

namespace fan_page.Infraestrutura.Repository
{
    public interface IPublicacaoRepository
    {
        IEnumerable<Publicacao> PegarFotosPublicadasNoPerfil(int id);
        void Publicar(Publicacao publicacao);
    }
}