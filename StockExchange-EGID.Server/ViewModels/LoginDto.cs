using System.ComponentModel.DataAnnotations;

namespace StockExchange_EGID.Server.Models
{
    public class LoginDto
    {
        [Required]
        [EmailAddress]
        [MaxLength(50)]
        public string Email { get; set; }
        [Required]
        [MinLength(5)]
        public string Password { get; set; }
    }
}
