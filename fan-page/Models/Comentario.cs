namespace fan_page.Models
{
    public class Comentario : ClasseBase
    {
        public int IdUsuario { get; set; }
        public int IdPublicacao { get; set; }
        public string Conteudo { get; set; }
        public DateTime DataDeCriacao { get; set; }
    }
}
