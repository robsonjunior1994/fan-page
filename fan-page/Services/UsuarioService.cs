using fan_page.Models;

namespace fan_page.Services
{
    public class UsuarioService : IUsuarioService
    {
        public void CriarAsync(Usuario usuario)
        {
            //Preciso resolver como manipular imagem, nesse momento vou receber a imagem e armazenar como um caminho url para exibir posteriorment
            //Precisamos ir no banco verificar se nomeDeUsuario e Email já existem
            //Usar o banco para armazenar
            throw new NotImplementedException();
        }
        public Usuario AtualizarAsync(Usuario usuario)
        {
            throw new NotImplementedException();
        }

        public void DesativarAsync(Usuario usuario)
        {
            throw new NotImplementedException();
        }

        public Usuario GetUsuarioAsync(Usuario usuario)
        {
            throw new NotImplementedException();
        }
    }
}
