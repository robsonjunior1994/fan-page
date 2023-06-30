using fan_page.Models;

namespace fan_page.Infraestrutura.Repository
{
    public interface IUsuarioRepository
    {
        void CriarUsuario(Usuario usuario);
        Usuario BuscarUsuario(string valor);

        Usuario VerificarUsuarioParaLogin(string email, string senha);
        Usuario PegarUsuarioPorToken(string tokenUsuario);
        void Atualizar(Usuario usuario);
    }
}
