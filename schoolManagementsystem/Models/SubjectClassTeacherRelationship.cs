using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace schoolManagementsystem.Models
{
    [Table("Subject_class_teacher_relationship")]
    public partial class SubjectClassTeacherRelationship
    {
        [Column("teacher_id")]
        public int? TeacherId { get; set; }
        [Column("student_id")]
        public int? StudentId { get; set; }
        [Column("class_id")]
        public int? ClassId { get; set; }
        [Key]
        [Column("SCT_ID")]
        public int SctId { get; set; }

        [ForeignKey(nameof(ClassId))]
        [InverseProperty("SubjectClassTeacherRelationships")]
        public virtual Class Class { get; set; }
        [ForeignKey(nameof(StudentId))]
        [InverseProperty(nameof(StudentDetail.SubjectClassTeacherRelationships))]
        public virtual StudentDetail Student { get; set; }
        [ForeignKey(nameof(TeacherId))]
        [InverseProperty(nameof(TeachersDetail.SubjectClassTeacherRelationships))]
        public virtual TeachersDetail Teacher { get; set; }
    }
}
