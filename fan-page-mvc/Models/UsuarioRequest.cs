using System.ComponentModel.DataAnnotations;

namespace fan_page_mvc.Models
{
    public class UsuarioRequest
    {
        [Required]
        public string NomeDoUsuario { get; set; }

        [Required]
        public string Senha { get; set; }
        [Required]
        [Compare("Senha")]
        public string ConfirmacaoDaSenha { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        [Compare("Email")]
        public string ConfirmacaoEmail { get; set; }
        [Required]
        public DateTime DataDeAniversario { get; set; }
        public string? ImagemDoPerfil { get; set; }
        public enum Type
        {
            Criador,
            Consumidor
        }
    }
}
