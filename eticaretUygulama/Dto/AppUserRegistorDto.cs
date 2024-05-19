using System.ComponentModel.DataAnnotations;

namespace eticaretUygulama.Dto
{
    public class AppUserRegistorDto
    {
        [Display(Name ="Adınız")]
        [Required(ErrorMessage ="Adınızı Boş Geçemezsiniz")]
        public string FirstName { get; set; }
        [Display(Name = "Soyadınız")]
        [Required(ErrorMessage = "Soyadınızı Boş Geçemezsiniz")]
        public string LastName { get; set; }
        [Display(Name = "Kullanıcı Adınızı Giriniz")]
        [Required(ErrorMessage = "Kullanıcı Adı Boş Geçemezsiniz")]
        public string UserName { get; set; }
        [Display(Name = "Şehir Girniz")]
        [Required(ErrorMessage = "Şehir Boş Geçemezsiniz")]
        public string City { get; set; }
        [Display(Name = "Email Girniz")]
        [Required(ErrorMessage = "Email Boş Geçemezsiniz")]
        public string Email { get; set; }
        [Display(Name = "Telefon Giriniz")]
        [Required(ErrorMessage = "Telefon Boş Geçemezsiniz")]
        public string PhoneNumber { get; set; }
        [Display(Name = "Şifrenizi Giriniz")]
        [Required(ErrorMessage = "Şifre Boş Geçemezsiniz")]
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
    }
}
