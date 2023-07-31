using StajProjesiAPI.Domain.Entities.Common;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using StajProjesiAPI.Domain.Enums;

namespace StajProjesiAPI.Domain.Entities
{
    public class AppUser : BaseEntity
    {
        
        public string FirstName { get; set; }       
        public string LastName { get; set; }       
        public string UserName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public byte[] PasswordSalt { get; set; }
        public byte[] PasswordHash { get; set; }
        public string Role { get; set; } = RoleEnum.User.ToString();
        public DateTime RefreshTokenEndDate { get; set; }
        public string? RefreshToken { get; set; }
        [NotMapped]
        public string Password { get; set; }
        [NotMapped]
        public string FullName { get { return this.FirstName + " " + this.LastName; } private set { } }
    }
}
