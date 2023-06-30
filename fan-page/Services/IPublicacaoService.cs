namespace fan_page.Services
{
    public interface IPublicacaoService
    {
        void Publicar(string tokenUsuario, string texto, IFormFile imagem);
    }
}
