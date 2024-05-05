using System.ComponentModel.DataAnnotations;

namespace CoreDemoYenii.Models
{
    public class UserSignUppViewModel
    {
        [Display(Name ="Ad Soyad")]
        [Required(ErrorMessage ="Lütfen Ad soyad Girin")]
        public string NameSurname { get; set; }

        [Display(Name = "Sifre")]
        [Required(ErrorMessage = "Lütfen Sifre Gir")]
        public string Passowrd { get; set; }

        [Display(Name ="Sifre tekrar")]
        [Required(ErrorMessage ="Lütfen Sifreyi Tekrar Gir")]
        public string ConfirmPassowrd {  get; set; }

        [Display(Name = "Mail Adresi")]
        [Required(ErrorMessage = "Lütfen Mail Adresini Gir")]
        public string Mail { get; set; }

        [Display(Name = "KullanıcıAdı")]
        [Required(ErrorMessage = "Lütfen KullanıcıAdı Gir")]
        public string UserName { get; set; }

        [Display(Name = "İmage")]
        [Required(ErrorMessage = "Image Url Kısmı")]
        public string ImageUrl { get; set; }
    }
}
