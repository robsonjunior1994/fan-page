using System.ComponentModel.DataAnnotations;

namespace fan_page.Models
{
    public class Usuario : ClasseBase
    {

        [Required]
        public string NomeDoUsuario { get; set; }
        [Required]
        [RegularExpression("@\"^(?=.*[a-z])(?=.*[A-Z])(?=.*\\d)(?=.*[^\\da-zA-Z]).{8,}$\"\r\n")]
        public string Senha { get; set; }
        [Required]
        [Compare("Password")]
        public string ConfirmacaoDaSenha { get; set; }
        [Required]
        [RegularExpression("@\"^[a-zA-Z0-9_.+-]+@[a-zA-Z0-9-]+\\.[a-zA-Z0-9-.]+$\"\r\n")]
        public string Email { get; set; }
        [Required]
        [Compare("Email")]
        public string ConfirmacaoEmail { get; set; }
        [Required]
        public DateTime DataDeAniversario { get; set; }
        [Required]
        public string ImagemDoPerfil { get; set; }
        public DateTime DataDeCriacao { get; set; }
        public enum Type 
        {
            Criador,
            Consumidor
        }
    }
}
