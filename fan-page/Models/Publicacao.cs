using System.ComponentModel.DataAnnotations;

namespace fan_page.Models
{
    public class Publicacao : ClasseBase
    {
        public int IdUsuario { get; set; }
        
        public string Texto { get; set; }
        public DateTime DataDeCriacao { get; set; } = DateTime.Now;
        public string? CaminhoImagemDaPublicacao { get; set; }

        //public List<int> NumeroDeCurtidas { get; set; }
        //public List<Comentario> Comentarios { get; set; }
        public Publicacao() { }
        public Publicacao(int idUsuario, string texto, string caminhoImagemDaPublicacao)
        {
            IdUsuario = idUsuario;
            Texto= texto;
            CaminhoImagemDaPublicacao = caminhoImagemDaPublicacao;
        }

    }
}
