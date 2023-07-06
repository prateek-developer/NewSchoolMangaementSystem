using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace schoolManagementsystem.Models
{
    [Table("student_attendance_detail")]
    public partial class StudentAttendanceDetail
    {
        [Key]
        [Column("attendance_id")]
        public int AttendanceId { get; set; }
        [Column("student_id")]
        public int StudentId { get; set; }
        [Column("date", TypeName = "date")]
        public DateTime Date { get; set; }
        [Column("status")]
        public int Status { get; set; }
        [Required]
        [Column("remarks")]
        [StringLength(1)]
        public string Remarks { get; set; }

        [ForeignKey(nameof(StudentId))]
        [InverseProperty(nameof(StudentDetail.StudentAttendanceDetails))]
        public virtual StudentDetail Student { get; set; }
    }
}
