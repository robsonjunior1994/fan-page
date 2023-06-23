using fan_page.Models;

namespace fan_page.Services
{
    public interface IUsuarioService
    {
        void CriarAsync(Usuario usuario);
        Usuario AtualizarAsync(Usuario usuario);
        void DesativarAsync(Usuario usuario);
        Usuario GetUsuarioAsync(Usuario usuario);
    }
}
