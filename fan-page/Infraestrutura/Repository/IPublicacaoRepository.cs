using fan_page.Models;

namespace fan_page.Infraestrutura.Repository
{
    public interface IPublicacaoRepository
    {
        void Publicar(Publicacao publicacao);
    }
}