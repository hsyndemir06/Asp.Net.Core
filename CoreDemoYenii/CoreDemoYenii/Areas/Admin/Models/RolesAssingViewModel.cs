namespace CoreDemoYenii.Areas.Admin.Models
{
    public class RolesAssingViewModel
    {
        public int RoleID { get; set; }
        public string Name { get; set; }
        public bool Exists { get; set; } // exist bu role kullanıcıda var mı ?
    }
}
