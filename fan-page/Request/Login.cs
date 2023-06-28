using System.ComponentModel.DataAnnotations;

namespace fan_page.Request
{
    public class Login
    {
        [Required]
        public string Email { get; set; }
        [Required]
        public string Senha { get; set; }
    }
}
