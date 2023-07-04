using fan_page.Models;

namespace fan_page.Infraestrutura.Repository
{
    public class PublicacaoRepository : IPublicacaoRepository
    {
        private readonly Context _context;
        public PublicacaoRepository()
        {
            _context = new Context();
        }

        public IEnumerable<Publicacao> PegarFotosPublicadasNoPerfil(int id)
        {
            IEnumerable<Publicacao> fotosDoPerfil = _context.Publicacao.ToList().Where(x => x.IdUsuario == id);
            return fotosDoPerfil;
        }

        public void Publicar(Publicacao publicacao)
        {
            _context.Publicacao.Add(publicacao);
            _context.SaveChanges();
        }
    }
}
