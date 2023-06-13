using System.ComponentModel.DataAnnotations;

namespace fan_page.Models
{
    public class User
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string UserName { get; set; }
        [Required]
        [RegularExpression("@\"^(?=.*[a-z])(?=.*[A-Z])(?=.*\\d)(?=.*[^\\da-zA-Z]).{8,}$\"\r\n")]
        public string Password { get; set; }
        [Required]
        [Compare("Password")]
        public string ConfirmePassword { get; set; }
        [Required]
        [RegularExpression("@\"^[a-zA-Z0-9_.+-]+@[a-zA-Z0-9-]+\\.[a-zA-Z0-9-.]+$\"\r\n")]
        public string Email { get; set; }
        [Required]
        [Compare("Email")]
        public string ConfirmeEmail { get; set; }
        [Required]
        public DateTime DateOfBirth { get; set; }
        [Required]
        public string ProfileImage { get; set; }
        public enum Type 
        {
            Producer,
            Consumer
        }
    }
}
