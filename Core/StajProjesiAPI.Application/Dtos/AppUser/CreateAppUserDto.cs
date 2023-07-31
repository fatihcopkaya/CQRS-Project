using System.ComponentModel.DataAnnotations;


namespace StajProjesiAPI.Application.Dtos.AppUser
{
    public class CreateAppUserDto 
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

        [Required(ErrorMessage = "Lütfen şifre alanını boş geçmeyiniz.")]
        [MinLength(6, ErrorMessage = "Password 6 karakterden az olamaz.")]
        [RegularExpression("(?=.*[a-z])(?=.*[A-Z]).*", ErrorMessage = "Password büyük ve küçük harf içermek zorundadır.")]
        public string Password { get; set; }
    }
}
