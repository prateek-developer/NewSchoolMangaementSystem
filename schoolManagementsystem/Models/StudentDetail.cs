using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace schoolManagementsystem.Models
{
    [Table("Student_details")]
    public partial class StudentDetail
    {
        public StudentDetail()
        {
            StudentAttendanceDetails = new HashSet<StudentAttendanceDetail>();
            SubjectClassTeacherRelationships = new HashSet<SubjectClassTeacherRelationship>();
        }

        [Key]
        [Column("Student_id")]
        public int StudentId { get; set; }
        [Required]
        [Column("email")]
        public string Email { get; set; }
        [Required]
        [Column("password")]
        [StringLength(50)]
        public string Password { get; set; }
        [Column("dob", TypeName = "date")]
        public DateTime Dob { get; set; }
        [Column("phone_no")]
        public int PhoneNo { get; set; }
        [Column("date_of_joining", TypeName = "date")]
        public DateTime DateOfJoining { get; set; }
        [Column("status")]
        public int Status { get; set; }
        [Column("class_id")]
        public int ClassId { get; set; }
        [Column("login_id")]
        public int? LoginId { get; set; }
        [Column("name")]
        [StringLength(50)]
        public string Name { get; set; }

        [ForeignKey(nameof(LoginId))]
        [InverseProperty(nameof(LoginDetail.StudentDetails))]
        public virtual LoginDetail Login { get; set; }
        [InverseProperty(nameof(StudentAttendanceDetail.Student))]
        public virtual ICollection<StudentAttendanceDetail> StudentAttendanceDetails { get; set; }
        [InverseProperty(nameof(SubjectClassTeacherRelationship.Student))]
        public virtual ICollection<SubjectClassTeacherRelationship> SubjectClassTeacherRelationships { get; set; }
    }
}
