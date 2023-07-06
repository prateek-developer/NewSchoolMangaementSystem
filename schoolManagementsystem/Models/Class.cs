using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace schoolManagementsystem.Models
{
    [Table("CLASS")]
    public partial class Class
    {
        public Class()
        {
            SubjectClassTeacherRelationships = new HashSet<SubjectClassTeacherRelationship>();
        }

        [Key]
        [Column("class_id")]
        public int ClassId { get; set; }
        [Column("teacher_id")]
        public int TeacherId { get; set; }
        [Required]
        [Column("class_name")]
        [StringLength(50)]
        public string ClassName { get; set; }

        [ForeignKey(nameof(TeacherId))]
        [InverseProperty(nameof(TeachersDetail.Classes))]
        public virtual TeachersDetail Teacher { get; set; }
        [InverseProperty(nameof(SubjectClassTeacherRelationship.Class))]
        public virtual ICollection<SubjectClassTeacherRelationship> SubjectClassTeacherRelationships { get; set; }
    }
}
