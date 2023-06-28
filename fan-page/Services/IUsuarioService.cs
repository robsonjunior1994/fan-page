using fan_page.Models;
using fan_page.Request;

namespace fan_page.Services
{
    public interface IUsuarioService
    {
        void Criar(Usuario usuario, IFormFile imageFile);
        Task<Usuario> Atualizar(Usuario usuario);
        void Desativar(Usuario usuario);
        Task<Usuario> GetUsuario(Usuario usuario);
        string FazerLogin(Login login);
    }
}
