using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System;

namespace schoolManagementsystem.ViewModel
{
    public class StudentDetailViewModel
    {

        [Key]
        [Column("Student_id")]
        public int StudentId { get; set; }
        [Column("email")]
      
        public string Email { get; set; }
        [Column("password")]
        
        public string Password { get; set; }
        [Column("dob", TypeName = "date")]
        public DateTime? Dob { get; set; }
        [Column("phone_no")]
        public int? PhoneNo { get; set; }
        [Column("date_of_joining", TypeName = "date")]
        public DateTime? DateOfJoining { get; set; }
        [Column("status")]
        public int? Status { get; set; }
        [Column("class_id")]
        public int? ClassId { get; set; }
        [Column("login_id")]
        public int? LoginId { get; set; }
        [Column("name")]
        [StringLength(50)]
        public string Name { get; set; }


    }
}
