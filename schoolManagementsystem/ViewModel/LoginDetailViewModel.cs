using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace schoolManagementsystem.ViewModel
{
    public class LoginDetailViewModel
    {

        [Key]
        [Column("login_ID")]
        public int LoginId { get; set; }
        [Required]
        [Column("username")]
        [StringLength(50)]
        public string Username { get; set; }
        [Required]
        [Column("password")]
        [StringLength(200)]
        public string Password { get; set; }
        [StringLength(10)]
        public string UserRole { get; set; }
        


    }
}
