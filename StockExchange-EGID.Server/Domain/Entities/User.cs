using Microsoft.AspNetCore.Identity;
using StockExchange_EGID.Server.Common.Enums;
using System.ComponentModel.DataAnnotations;

namespace StockExchange_EGID.Server.Domain.Entities
{
    public class User : IdentityUser
    {
        
        [MaxLength(50)]
        public string? FirstName { get; set; }
        [MaxLength(50)]
        public string? LastName { get; set; }
        [Required(ErrorMessage ="User Email is required")]
        [MaxLength(100)]
        [EmailAddress]
        [ProtectedPersonalData]
        public override string? Email { get; set; }
        public string? Password { get; set; }

        [EnumDataType(typeof(UserRole),ErrorMessage ="User Role Must be: user or admin")]
        public string? Role { get; set; }
        [MaxLength(200)]
        [DataType(DataType.DateTime)]
        public DateTime CreatedAt { get; set; }

    }
}
