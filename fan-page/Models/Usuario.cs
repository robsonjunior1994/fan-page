using System.ComponentModel.DataAnnotations;
using System.Runtime.InteropServices;

namespace fan_page.Models
{
    public class Usuario : ClasseBase
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
        public DateTime DataDeCriacao { get; set; } = DateTime.Now;
        public enum Type
        {
            Criador,
            Consumidor
        }
        public string? Token { get; set; }
    }
}
