using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace schoolManagementsystem.Models
{
    [Table("login_details")]
    public partial class LoginDetail
    {
        public LoginDetail()
        {
            LeaveDetails = new HashSet<LeaveDetail>();
            Notices = new HashSet<Notice>();
            StudentDetails = new HashSet<StudentDetail>();
            TeachersDetails = new HashSet<TeachersDetail>();
        }

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
        [Column("is_approved")]
        public bool IsApproved { get; set; }
        [Required]
        [Column("token")]
        [StringLength(100)]
        public string Token { get; set; }
        [Column("token_expired")]
        public int TokenExpired { get; set; }
        [Required]
        [Column("user_role")]
        [StringLength(10)]
        public string UserRole { get; set; }

        [InverseProperty(nameof(LeaveDetail.AppliedByNavigation))]
        public virtual ICollection<LeaveDetail> LeaveDetails { get; set; }
        [InverseProperty(nameof(Notice.IssuedByNavigation))]
        public virtual ICollection<Notice> Notices { get; set; }
        [InverseProperty(nameof(StudentDetail.Login))]
        public virtual ICollection<StudentDetail> StudentDetails { get; set; }
        [InverseProperty(nameof(TeachersDetail.Login))]
        public virtual ICollection<TeachersDetail> TeachersDetails { get; set; }
    }
}
