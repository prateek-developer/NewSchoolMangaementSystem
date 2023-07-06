using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace schoolManagementsystem.Models
{
    [Table("Subject")]
    public partial class Subject
    {
        [Key]
        [Column("subject_id")]
        public int SubjectId { get; set; }
        [Column("subject_name")]
        [StringLength(1)]
        public string SubjectName { get; set; }
    }
}
