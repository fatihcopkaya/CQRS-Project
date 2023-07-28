using StajProjesiAPI.Domain.Entities.Common;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using StajProjesiAPI.Domain.Enums;

namespace StajProjesiAPI.Domain.Entities
{
    public class AppUser : BaseEntity
    {
        [Required(ErrorMessage = "First name alanı zorunludur.")]
        [MaxLength(50, ErrorMessage = "First name 50 karakteri geçemez")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Last name alanı zorunludur.")]
        [MaxLength(50, ErrorMessage = "Last name 50 karakteri geçemez.")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Username alanı zorunludur.")]
        [MaxLength(30, ErrorMessage = "Username 30 karakteri geçemez")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Lütfen e-posta adresinizi boş geçmeyiniz.")]
        [EmailAddress(ErrorMessage = "Lütfen uygun formatta e-posta giriniz.")]
        [MaxLength(100, ErrorMessage = "Email 100 karakterden büyük olamaz.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Phone number alanı zorunludur")]
        [MaxLength(20, ErrorMessage = "Phone number alanı 30 karakterden büyük olamaz.")]
        public string PhoneNumber { get; set; }
        public byte[] PasswordSalt { get; set; }
        public byte[] PasswordHash { get; set; }
        public string Role { get; set; } = RoleEnum.User.ToString();
        public DateTime RefreshTokenEndDate { get; set; }
        public string? RefreshToken { get; set; }
        public bool IsActived { get; set; }
        [NotMapped]
        public string Password { get; set; }
        [NotMapped]
        public string FullName { get { return this.FirstName + " " + this.LastName; } private set { } }
    }
}
