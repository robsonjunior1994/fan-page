using fan_page.Infraestrutura.Repository;
using fan_page.Models;

namespace fan_page.Services
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IUsuarioRepository _repository;
        public UsuarioService(IUsuarioRepository usuarioRepository)
        {
            _repository = usuarioRepository;
        }
        public async void CriarAsync(Usuario usuario, IFormFile imageFile)
        {
            var existeNomeDeUsuario = _repository.BuscarUsuario(usuario.NomeDoUsuario);
            var existeEmailDoUsuario = _repository.BuscarUsuario(usuario.Email);

            if(existeNomeDeUsuario != null  || existeEmailDoUsuario != null) 
            {
                return;
            }

            // Gere um nome de arquivo único para a imagem
            string fileName = Guid.NewGuid().ToString() + Path.GetExtension(imageFile.FileName);

            // Determine o caminho completo para salvar a imagem
            string filePath = Path.Combine("C:\\projetos\\fan-page\\fan-page\\Midias\\FotoDePerfil", fileName);

            usuario.ImagemDoPerfil = filePath;
            // Salve a imagem no disco
            using (var fileStream = new FileStream(filePath, FileMode.Create))
            {
                await imageFile.CopyToAsync(fileStream);
            }

            _repository.CriarUsuario(usuario);
        }
        public async Task<Usuario> AtualizarAsync(Usuario usuario)
        {
            throw new NotImplementedException();
        }

        public async void DesativarAsync(Usuario usuario)
        {
            throw new NotImplementedException();
        }

        public async Task<Usuario> GetUsuarioAsync(Usuario usuario)
        {
            throw new NotImplementedException();
        }
    }
}
