using fan_page.Models;

namespace fan_page.Services
{
    public interface IUsuarioService
    {
        void CriarAsync(Usuario usuario, IFormFile imageFile);
        Task<Usuario> AtualizarAsync(Usuario usuario);
        void DesativarAsync(Usuario usuario);
        Task<Usuario> GetUsuarioAsync(Usuario usuario);
    }
}
