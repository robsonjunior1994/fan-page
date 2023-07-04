using fan_page.Infraestrutura.Repository;
using fan_page.Models;

namespace fan_page.Services
{
    public class PublicacaoService : IPublicacaoService
    {
        private readonly IPublicacaoRepository _publicacaoRepository;
        private readonly IUsuarioRepository _usuarioRepository;
        public PublicacaoService(IPublicacaoRepository publicacaoRepository, IUsuarioRepository usuarioRepository)
        {
            _publicacaoRepository = publicacaoRepository;
            _usuarioRepository = usuarioRepository;
        }

        public IEnumerable<Publicacao> PegarFotosPublicadasNoPerfil(int id)
        {
            var fotosDoPerfil = _publicacaoRepository.PegarFotosPublicadasNoPerfil(id);
            return fotosDoPerfil;
        }

        public void Publicar(string tokenUsuario, string texto, IFormFile imagem)
        {
            
            Usuario usuario = _usuarioRepository.PegarUsuarioPorToken(tokenUsuario);

            var caminhoImagemDaPublicacao = SalvaImagemEmDisco(imagem);

            Publicacao publicacao = new Publicacao(usuario.Id, texto, caminhoImagemDaPublicacao);

            _publicacaoRepository.Publicar(publicacao);
        }

        //Esse método se repete em UsuarioService, posso verificar a possibilidade de levar ele para se reaproveitado
        private string SalvaImagemEmDisco(IFormFile imageFile)
        {
            // Gere um nome de arquivo único para a imagem
            string fileName = Guid.NewGuid().ToString() + Path.GetExtension(imageFile.FileName);

            // Determine o caminho completo para salvar a imagem
            string filePath = Path.Combine("C:\\projetos\\fan-page\\fan-page\\Midias\\FotoPostagem", fileName);

            // Salve a imagem no disco
            using (var fileStream = new FileStream(filePath, FileMode.Create))
            {
                imageFile.CopyToAsync(fileStream);
            }

            return filePath;
        }
    }
}
