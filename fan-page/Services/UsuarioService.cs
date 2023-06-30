using fan_page.Infraestrutura.Repository;
using fan_page.Models;
using fan_page.Request;
using System.Security.Cryptography;
using System.Text;

namespace fan_page.Services
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IUsuarioRepository _repository;
        public UsuarioService(IUsuarioRepository usuarioRepository)
        {
            _repository = usuarioRepository;
        }
        public void Criar(Usuario usuario, IFormFile imageFile)
        {
            if (NomedeusuarioOuEmailExiste(usuario))
            {
                throw new Exception("nomeDeUsuario ou E-mail existente");
            }

            var caminhoDaImagem = SalvaImagemEmDisco(imageFile);

            usuario.ImagemDoPerfil = caminhoDaImagem;

            _repository.CriarUsuario(usuario);
        }

        public string FazerLogin(Login login)
        {
            var usuario = _repository.VerificarUsuarioParaLogin(login.Email, login.Senha);
            if(usuario != null)
            {
                var token = GerarToken(login);
                usuario.Token = token;

                _repository.Atualizar(usuario);
                return token;
            }
            
            throw new Exception("e-mail ou senha incorreto.");
        }

        private static string GerarToken(Login login)
        {
            using (var sha256 = SHA256.Create())
            {
                byte[] inputBytes = Encoding.UTF8.GetBytes(login.Email + DateTime.Now);
                byte[] hashBytes = sha256.ComputeHash(inputBytes);
                string hash = Convert.ToBase64String(hashBytes);
                
                return hash;
            }
        }

        public async Task<Usuario> Atualizar(Usuario usuario)
        {
            throw new NotImplementedException();
        }

        public async void Desativar(Usuario usuario)
        {
            throw new NotImplementedException();
        }

        public async Task<Usuario> GetUsuario(Usuario usuario)
        {
            throw new NotImplementedException();
        }

        private bool NomedeusuarioOuEmailExiste(Usuario usuario)
        {
            //Preciso performar melhor isso aqui, pois estou indo no banco 2x
            var existeNomeDeUsuario = _repository.BuscarUsuario(usuario.NomeDoUsuario);
            var existeEmailDoUsuario = _repository.BuscarUsuario(usuario.Email);
            if (existeNomeDeUsuario != null || existeEmailDoUsuario != null)
            {
                return true;
            }

            return false;
        }

        //Esse método se repete em PublicacaoService, posso verificar a possibilidade de levar ele para se reaproveitado
        private static string SalvaImagemEmDisco(IFormFile imageFile)
        {
            // Gere um nome de arquivo único para a imagem
            string fileName = Guid.NewGuid().ToString() + Path.GetExtension(imageFile.FileName);

            // Determine o caminho completo para salvar a imagem
            string filePath = Path.Combine("C:\\projetos\\fan-page\\fan-page\\Midias\\FotoDePerfil", fileName);

            // Salve a imagem no disco
            using (var fileStream = new FileStream(filePath, FileMode.Create))
            {
                imageFile.CopyToAsync(fileStream);
            }

            return filePath;
        }
    }
}
