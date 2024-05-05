using System.ComponentModel.DataAnnotations;

namespace CoreDemoYenii.Models
{
    public class AddRoleModel
    {
        [Required(ErrorMessage = "Lütfen Rol Adı Girin")]
        public string Name { get; set; }
    }
}
