using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace schoolManagementsystem.Models
{
    [Table("NOTICE")]
    public partial class Notice
    {
        [Key]
        [Column("notice_id")]
        public int NoticeId { get; set; }
        [Required]
        [Column("notice_details")]
        public string NoticeDetails { get; set; }
        [Column("issued_on", TypeName = "date")]
        public DateTime IssuedOn { get; set; }
        [Column("issued_by")]
        public int IssuedBy { get; set; }

        [ForeignKey(nameof(IssuedBy))]
        [InverseProperty(nameof(LoginDetail.Notices))]
        public virtual LoginDetail IssuedByNavigation { get; set; }
    }
}
