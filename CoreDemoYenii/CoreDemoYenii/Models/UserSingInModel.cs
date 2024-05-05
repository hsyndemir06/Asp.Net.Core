using System.ComponentModel.DataAnnotations;

namespace CoreDemoYenii.Models
{
    public class UserSingInModel
    {
        [Required(ErrorMessage ="Lutfen kullanıcı adı girin")]
        public string  usurname { get; set; }


        [Required(ErrorMessage = "Lutfen sifre girin")]
        public string  password { get; set; }
    }
}
