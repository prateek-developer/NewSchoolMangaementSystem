using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System;

namespace schoolManagementsystem.ViewModel
{
    public class NoticeViewModel
    {

        [Key]
        [Column("notice_id")]
        public int NoticeId { get; set; }
        [Column("notice_details")]
        
        public string NoticeDetails { get; set; }
        [Column("issued_on", TypeName = "date")]
        public DateTime? IssuedOn { get; set; }
        [Column("issued_by")]
        public int? IssuedBy { get; set; }
    }
}
