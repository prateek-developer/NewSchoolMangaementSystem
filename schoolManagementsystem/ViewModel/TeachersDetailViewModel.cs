using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System;
using schoolManagementsystem.Models;

namespace schoolManagementsystem.ViewModel
{
    public class TeachersDetailViewModel
    {

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
        public int LoginId { get; set; }
        [Required]
        [Column("email")]
        [StringLength(50)]
        public string Email { get; set; }
        [Required]
        [Column("password")]
        [StringLength(100)]
        public string Password { get; set; }


    }
}
