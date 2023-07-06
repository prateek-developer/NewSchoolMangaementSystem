using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace schoolManagementsystem.Models
{
    [Table("teachers_detail")]
    public partial class TeachersDetail
    {
        public TeachersDetail()
        {
            Classes = new HashSet<Class>();
            SubjectClassTeacherRelationships = new HashSet<SubjectClassTeacherRelationship>();
        }

        [Key]
        [Column("teacher_id")]
        public int TeacherId { get; set; }
        [Required]
        [Column("name")]
        [StringLength(100)]
        public string Name { get; set; }
        [Required]
        [Column("subject_taught")]
        [StringLength(100)]
        public string SubjectTaught { get; set; }
        [Column("salary")]
        public int Salary { get; set; }
        [Column("dob", TypeName = "date")]
        public DateTime Dob { get; set; }
        [Column("login_id")]
        public int? LoginId { get; set; }
        [Required]
        [Column("email")]
        [StringLength(50)]
        public string Email { get; set; }
        [Required]
        [Column("password")]
        [StringLength(100)]
        public string Password { get; set; }

        [ForeignKey(nameof(LoginId))]
        [InverseProperty(nameof(LoginDetail.TeachersDetails))]
        public virtual LoginDetail Login { get; set; }
        [InverseProperty(nameof(Class.Teacher))]
        public virtual ICollection<Class> Classes { get; set; }
        [InverseProperty(nameof(SubjectClassTeacherRelationship.Teacher))]
        public virtual ICollection<SubjectClassTeacherRelationship> SubjectClassTeacherRelationships { get; set; }
    }
}
